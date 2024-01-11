using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Encuesta
{
    public class RespuestaModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public int Pregunta_id { get; set; }
        public string Respuesta { get; set; }
        public string Num_elemento { get; set; }
        public string Values { get; set; }
    }
}