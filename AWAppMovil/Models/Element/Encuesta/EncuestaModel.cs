using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Encuesta
{
    public class EncuestaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Vigente { get; set; }
        public string Vigencia { get; set; }
        public int Relacion_id { get; set; }
        public string Num_elemento { get; set; }
    }
}