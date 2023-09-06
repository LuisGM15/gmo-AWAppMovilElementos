using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Support.Account
{
    public class SupportAuthModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Tema_id { get; set; }
        public string Tema { get; set; }
        public string Status { get; set; }

    }
}