using LDCWS.DA;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDCWS.Service
{
    public class BaseClass
    {
        protected readonly AppDBContext _appDBContext;

        public BaseClass(AppDBContext appDBCONTEXT)
        {
            _appDBContext = appDBCONTEXT;
        }
    }
}
