
using AWAppMovil.Class.Element.Incident;
using AWAppMovil.Models;
using AWAppMovil.Models.Element.Incident;
using System;
using System.Collections.Generic;

using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Incident
{
    public class ElementIncidentController : ApiController
    {
        //API TEMPORAL QUE OBTIENE LAS 15 INCIDENCIAS (RECIBIENDO LAS 15 FECHAS)
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

        //API  NUEVA QUE SOLO NECESITA UNA FECHA (DIA EN CURSO)
        [HttpPost]
        [Route("element/get-incidencias-15-dias")]
        public List<IncidenciaElementoModel> Get15Dias([FromBody] IncidenciaElementoModel inc)
        {
            return ElementIncidentClass.GetIncidencias15dias(inc.Num_Empleado, inc.Servicio);
        }

        //API PARA OBTENER LOS DOBLETES (SOLO AEROPUERTO)
        [HttpPost]
        [Route("element/get-dobletes-aeropuerto")]
        public List<IncidenciaElementoModel> GetDobletesAeropuerto([FromBody] IncidenciaElementoModel i)
        {
            return ElementIncidentClass.GetDobletesAeropuerto(i.Num_Empleado);
        }

        // OBTIENE EL CATALOGO DE INCIDENCIAS
        [HttpGet]
        [Route("element/get-catalogo-incidencias")]
        public List<IncidenciaModel> GetCatalogoIncidencias()
        {
            return ElementIncidentClass.GetCatalogoIncidencias();
        }

        //OBTIENE EL PROYECTO AL CUAL PERTENECE EL ELEMENTO
        [HttpPost]
        [Route("element/get-proyecto")]
        public ProyectoIncidenciaModel GetProyecto([FromBody] ProyectoIncidenciaModel p)
        {
            return ElementIncidentClass.GetProyectoElemento(p.Num_elemento);
        }
    }
}