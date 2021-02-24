using LDCWS.Auth;
using LDCWS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDCWS.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTAuth IJWTAuth;
        private readonly ILogin _ilogin;

        public LoginController(IJWTAuth jwtAuth, ILogin iLogin)
        {
            this.IJWTAuth = jwtAuth;
            this._ilogin = iLogin;
        }

        [AllowAnonymous]
        [Route("api/Login/authenticate")]
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] UserCredential usercredential)

        {

          bool isLoginVerify =   _ilogin.getLoginVerify(usercredential.username, usercredential.password);
            unAuthorize unAuthe = new unAuthorize();
            if (isLoginVerify) 
            {
                Token token = new Token();
                token.token = IJWTAuth.Authenticate(usercredential.username);
                
               

                if (token.token != null)
                {
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            } 
            else
            {
                unAuthe.errorCode = "400";
                unAuthe.errorMessage = "username or password is incorrect!. ";
                return BadRequest(unAuthe);
            }
            
                
            

        }
    }
}
