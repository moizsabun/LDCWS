using System;
using System.Collections.Generic;
using System.Text;

namespace LDCWS.Service.Interfaces
{
   public interface ILogin
    {
        bool getLoginVerify(string userName, string Password);
    }
}
