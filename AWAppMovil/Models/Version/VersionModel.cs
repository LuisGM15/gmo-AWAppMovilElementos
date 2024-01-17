using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Version
{
    public class VersionModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public int Num_aplicacion { get; set; }
        public string Version { get; set; }
        public int Vigencia { get; set; }
        public string Fecha { get; set; }
    }
}