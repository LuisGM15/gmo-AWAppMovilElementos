using AWAppMovil.Class.Element.Profile;
using AWAppMovil.Models.Element.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Profile
{
    public class ElementProfileController : ApiController
    {
        [HttpPost]
        [Route("element/get-profile")]
        public ElementProfileModel GetProfile([FromBody] ElementProfileModel element)
        {
            return ElementProfileClass.GetProfile(element.Num_empleado);
        }

        [HttpPost]
        [Route("element/get-images")]
        public List<ElementFileModel> getImages([FromBody] ElementFileModel file)
        {
            return ElementProfileClass.getPhotos(file.Num_empleado);
        }

        [HttpPost]
        [Route("element/get-avatar")]
        public ElementFileModel getAvatar([FromBody] ElementFileModel file)
        {
            return ElementProfileClass.getAvatar(file.Num_empleado);
        }
    }
}