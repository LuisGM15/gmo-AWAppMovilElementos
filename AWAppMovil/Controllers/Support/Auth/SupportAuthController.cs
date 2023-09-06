using AWAppMovil.Class.Support.Auth;
using AWAppMovil.Models.Support.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AWAppMovil.Controllers.Support.Auth
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class SupportAuthController : ApiController
    {
        [HttpPost]
        [Route("support/auth/login")]
        public SupportAuthModel SupportLogin([FromBody] SupportAuthModel auth)
        {
            return SupportAuthClass.Login(auth.Nombre, auth.Password);
        }
    }
}