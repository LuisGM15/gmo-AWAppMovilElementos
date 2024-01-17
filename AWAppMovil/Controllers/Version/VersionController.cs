using AWAppMovil.Class.Version;
using AWAppMovil.Models.Version;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Version
{
    public class VersionController : ApiController
    {
        [HttpPost]
        [Route("version/check-version-actual")]
        public VersionModel CheckVersionActual([FromBody] VersionModel version)
        {
            return VersionClass.CheckVersionActual(version.Version);
        }
    }
}