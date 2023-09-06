using AWAppMovil.Class.Element.Notices;
using AWAppMovil.Models.Element.Notices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Notices
{
    public class ElementNoticesController : ApiController
    {
        //RETORNA LAS ULTIMAS 5 NOTICIAS PUBLICADAS
        [HttpGet]
        [Route("element/notices/get-top-5")]
        public List<ElementNoticeModel> GetTop5Notices()
        {
            return ElementNoticesClass.GetTop5Notices();
        }
        
        //RETORNA LA LISTA DE NOTICIAS
        [HttpGet]
        [Route("element/notices/get")]
        public List<ElementNoticeModel> GetElementNotices()
        {
            return ElementNoticesClass.GetNotices();
        }

        //RETORNA UNA NOTICIA MEDIANTE SU ID
        [HttpPost]
        [Route("element/notices/get-by-id")]
        public ElementNoticeModel GetNoticeById([FromBody] ElementNoticeModel notice)
        {
            return ElementNoticesClass.GetNoticeById(notice.Id);
        }
    }
}