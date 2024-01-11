using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Encuesta
{
    public class RElementoEncuestaModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Num_elemento { get; set; }
        public int Encuesta_id { get; set; }
        public string Comentarios { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}