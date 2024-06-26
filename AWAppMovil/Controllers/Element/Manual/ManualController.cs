using AWAppMovil.Class.Element.Manual;
using AWAppMovil.Models.Element.Manual;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Manual
{
    public class ManualController : ApiController
    {
        [HttpGet]
        [Route("manual/get")]
        public ManualModel GetManualUsuario()
        {
            return ManualClass.GetManualUsuario();
        }
    }
}