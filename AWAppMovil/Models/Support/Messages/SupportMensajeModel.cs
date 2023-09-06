using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Support.Messages
{
    public class SupportMensajeModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Sala_id { get; set; }
        public string Num_empleado { get; set; }
        public string Soporte_id { get; set; }
        public string Contenido { get; set; }
        public string Fecha { get; set; }
        public string Visto { get; set; }
    }
}