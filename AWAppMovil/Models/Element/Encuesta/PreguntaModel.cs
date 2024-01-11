using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Encuesta
{
    public class PreguntaModel
    {
        public int Id { get; set; }
        public int Encuesta_id { get; set; }
        public string Pregunta { get; set; }
        public int Tipo { get; set; }
        public int Posicion { get; set; }

        public int Obligatorio { get; set; }
    }
}