using System; 
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LDCWS.Auth;
using LDCWS.DA;
using LDCWS.Service;
using LDCWS.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace LDCWS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContextPool<AppDBContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("LDCWS"),
              b => b.MigrationsAssembly("LDCWS")));
            
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers(options => options.EnableEndpointRouting = false);

            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
             .SetCompatibilityVersion(CompatibilityVersion.Version_3_0); ;
            services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.UseMemberCasing();
        });

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                // Register other policies here
            });

            
            string key = "LDC_AutomAtion_KE22122020_80017437";

            services.AddCors(options =>
            {
                options.AddPolicy("myCorsPolicy",
                    builder =>
                    {
                        //Do not use `http://localhost:3000/`
                        builder
                                    .AllowAnyHeader()
                                    .AllowAnyMethod().WithOrigins("http://ncm-uat-srv:3000", "http://ncm-uat-srv:3001", "http://localhost:3000" , "http://localhost:3001");
                    });
            });
            services.AddAuthorization();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

                ).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false,


                    };
                });


            services.AddScoped<ILogin, LoginService>();
            services.AddScoped<IMasterData, MasterDataService>();
            services.AddScoped<ILoadSheding, LoadSheddingService>();
            services.AddSingleton<IJWTAuth>(new JWTAuth(key));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          //  app.UseAuthentication();
            app.UseCors("myCorsPolicy");
            app.UseCors(builder => builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          );


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
          
            app.UseAuthentication();
            app.UseMvc();
            app.UseRouting();
            

        }
    }
}
