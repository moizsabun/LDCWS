using LDCWS.BO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDCWS.DA.Configurations
{
    class userRoleConfigurations : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData( new UserRole{ 
            userRoleID = 1,
            userRoleDesc = "System",
            userRoleAddDateTime = DateTime.Now
            },

            new UserRole
            {
                userRoleID = 2,
                userRoleDesc = "Admin",
                userRoleAddDateTime = DateTime.Now
            },

            new UserRole
            {
                userRoleID = 3,
                userRoleDesc = "user",
                userRoleAddDateTime = DateTime.Now
            }
            );
        }
    }
}
