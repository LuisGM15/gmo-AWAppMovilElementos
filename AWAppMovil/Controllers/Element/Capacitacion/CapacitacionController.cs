using AWAppMovil.Class.Element.Capacitacion;
using AWAppMovil.Models.Element.Capacitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Capacitacion
{
    public class CapacitacionController : ApiController
    {
        [HttpGet]
        [Route("capacitacion/get-modulos")]
        public List<ModuloModel> GetModulosCapacitacion()
        {
            return CapacitacionClass.GetModulosCapacitacion();
        }

        [HttpPost]
        [Route("capacitacion/get-materiales-por-modulo")]
        public List<MaterialModel> GetMaterialesPorModulo([FromBody] MaterialModel m)
        {
            return CapacitacionClass.GetMaterialPorModulo(m.Modulo_id);
        }
    }
}