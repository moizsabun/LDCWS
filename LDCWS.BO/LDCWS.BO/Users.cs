using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LDCWS.BO
{
   public class Users
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public int userRoleID { get; set; }
        public int userAddedby { get; set; }
        public DateTime userAddedDate { get; set; }
     
    }
}
