using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Messages
{
    public class ElementSalaModel
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Tema_id { get; set; }
        public string Tema { get; set; }
        public string Num_empleado { get; set; }
        public string Fecha { get; set; }
    }
}