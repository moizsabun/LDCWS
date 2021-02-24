using LDCWS.BO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDCWS.DA.Configurations
{
    public class usersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
           
            builder.HasData( new Users{
                userID =1,
                userName = "Admin",
                userPassword = "Admin",
                userAddedby = 1,
                userAddedDate =DateTime.Now,
                userRoleID =2
               
            },
          new Users {
                userID = 2,
                userName = "user2",
                userPassword = "user2",
                userAddedby = 1,
                userAddedDate = DateTime.Now,
                userRoleID = 3


            });
        }
    }
}
