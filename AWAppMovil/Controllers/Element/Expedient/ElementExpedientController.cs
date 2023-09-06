using AWAppMovil.Class.Element.Expedient;
using AWAppMovil.Models.Element.Expedient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Expedient
{
    public class ElementExpedientController : ApiController
    {
        [HttpPost]
        [Route("element/get-expedient")]
        public List<ElementExpedientModel> getExpedient([FromBody] ElementExpedientModel exp)
        {
            return ElementExpedientClass.GetExpedient(exp.Num_empleado);
        }
    }
}