using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDCWS.Auth
{
   public interface IJWTAuth
    {
       string Authenticate(string userid);
    }
}
