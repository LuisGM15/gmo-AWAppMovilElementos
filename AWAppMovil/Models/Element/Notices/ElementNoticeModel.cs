using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Models.Element.Notices
{
    public class ElementNoticeModel
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public int Formato { get; set; }
        public int Sitio { get; set; }
        public int Visible { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get;set; }

    }
}