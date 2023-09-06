
using AWAppMovil.Class.Element.Incident;
using AWAppMovil.Models;
using AWAppMovil.Models.Element.Incident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Incident
{
    public class ElementIncidentController : ApiController
    {
        [HttpPost]
        [Route("element/get-incidents")]
        public List<ElementIncidentModel> getIncidents([FromBody] ElementIncidentModel inc )
        {
            return ElementIncidentClass.GetIncidents(
                inc.Num_empleado, 
                inc.Proyecto, 
                inc.Subproyecto, 
                inc.Servicio, 
                inc.F1,
                inc.F2,
                inc.F3,
                inc.F4,
                inc.F5,
                inc.F6,
                inc.F7,
                inc.F8,
                inc.F9,
                inc.F10,
                inc.F11,
                inc.F12,
                inc.F13,
                inc.F14,
                inc.F15
             );
        }        
    }
}