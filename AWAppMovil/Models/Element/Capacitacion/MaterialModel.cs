using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Capacitacion
{
    public class MaterialModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        public int Modulo_id { get; set; }
        public int Tipo { get; set; }
    }
}