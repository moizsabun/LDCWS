using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LDCWS.Auth
{
    public class JWTAuth : IJWTAuth
    {

        private readonly IDictionary<string, string> users = new Dictionary<string, string> {
            {"admin", "admin" },{"user", "password" }
        };

        private readonly string key;

        public JWTAuth(string key)
        {
            this.key = key;
        }
        public string Authenticate(string userid)
        {
            //if(!users.Any(u => u.Key == userid &&  u.Value == password))
            //{
            //    return null;
            //}

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userid) , new Claim(ClaimTypes.Role, "Admin")}),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                
                };

            var token =  tokenHandler.CreateToken(tokenDescriptior);
            
            return tokenHandler.WriteToken(token);

        }

    }
}
