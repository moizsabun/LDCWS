using LDCWS.DA;
using LDCWS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDCWS.Service
{
    public class LoginService : BaseClass, ILogin
    {

        public LoginService(AppDBContext appDbContext) : base(appDbContext)
        {

        }
        public bool getLoginVerify(string userName, string Password)
        {
            var data = _appDBContext.Users.Where(search => search.userName == userName && search.userPassword == Password).ToList();
            if(data.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
