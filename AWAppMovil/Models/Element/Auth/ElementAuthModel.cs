using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Auth
{
    public class ElementAuthModel
    {
        public bool Success { get; set; }
        public string Num_empleado { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }

        public string Proyecto_id { get; set; }
        public string Subproyecto_id { get; set; }
        public string Servicio_id { get; set; }
    }
}