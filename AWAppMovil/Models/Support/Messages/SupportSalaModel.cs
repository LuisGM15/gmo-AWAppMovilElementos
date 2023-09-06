using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Support.Messages
{
    public class SupportSalaModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Tema_id { get; set; }
        public string Num_empleado { get; set; }
        public string Fecha { get; set; }
        public string Elemento { get; set; }
    }
}