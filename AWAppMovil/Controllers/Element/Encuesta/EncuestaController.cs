using AWAppMovil.Class.Element.Encuesta;
using AWAppMovil.Models.Element.Encuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element.Encuesta
{
    public class EncuestaController : ApiController
    {
        [HttpPost]
        [Route("encuesta/get-vigentes")]
        public List<EncuestaModel> GetEncuestasVigentes([FromBody] EncuestaModel e)
        {
            return EncuestaClass.GetEncuestasVigentes(e.Num_elemento);
        }

        [HttpPost]
        [Route("encuesta/get-preguntas-by-encuesta")]
        public List<PreguntaModel> GetPreguntasByEncuesta([FromBody] PreguntaModel p)
        {
            return EncuestaClass.GetPreguntasByEncuesta(p.Encuesta_id);
        }

        [HttpPost]
        [Route("encuesta/save-respuestas")]
        public RespuestaModel SavePreguntas([FromBody] RespuestaModel resp)
        {
            return EncuestaClass.SaveRespuestas(resp.Values);
        }

        [HttpPost]
        [Route("encuesta/save-registro-encuesta-finalizada")]
        public RElementoEncuestaModel SaveRegistroEncuestaFinalizada([FromBody] RElementoEncuestaModel ree)
        {
            return EncuestaClass.SaveRegistroEncuestaFinalizada(ree.Num_elemento, ree.Encuesta_id, ree.Comentarios);
        }
    }
}