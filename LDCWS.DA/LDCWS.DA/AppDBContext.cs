using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LDCWS.BO;
using LDCWS.DA.Configurations;

namespace LDCWS.DA
{
   public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<MasterData> MasterData { get; set; }
        public DbSet<MasterDataArchive> ArchiveMasterData { get; set; }
        public DbSet<LoadShedding> loadShedding { get; set; }
        public DbSet<LoadSheddingArchive> ArchiveloadShedding { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new usersConfiguration());
            builder.ApplyConfiguration(new userRoleConfigurations());
        }
    }


    
}
