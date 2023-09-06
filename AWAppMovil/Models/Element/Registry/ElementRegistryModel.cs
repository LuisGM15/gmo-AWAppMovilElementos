using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Registry
{
    public class ElementRegistryModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Num_empleado { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string Created_at { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Curp { get; set; }

    }
}