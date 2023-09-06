using AWAppMovil.Class.Element.Auth;
using AWAppMovil.Models.Element.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Auth
{
    public class ElementAuthController : ApiController
    {
        [HttpPost]
        [Route("element/auth")]
        public List<ElementAuthModel> elementAuth([FromBody] ElementAuthModel element)
        {
            return ElementAuthClass.elementAuth(element.Num_empleado, element.Password);
        }
    }
}