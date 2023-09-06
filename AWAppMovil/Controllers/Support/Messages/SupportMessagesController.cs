using AWAppMovil.Class.Support.Messages;
using AWAppMovil.Models.Support.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AWAppMovil.Controllers.Support.Messages
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

    public class SupportMessagesController : ApiController
    {

        //RETORNA TODAS LAS SALAS (DEPENDIENDO DEL TEMA DE AYUDA)
        [HttpPost]
        [Route("support/messages/salas/get")]
        public List<SupportSalaModel> GetSalas([FromBody] SupportSalaModel sala)
        {
            return SupportMessagesClass.GetSalas(sala.Tema_id);
        }

        //RETORNA TODOS LOS MENSAJES (DE ACUERDO A LA SALA Y AL ELEMENTO SELECCIONADOS)
        [HttpPost]
        [Route("support/messages/get-by-sala")]
        public List<SupportMensajeModel> GetMessagesBySalaAndElement([FromBody] SupportMensajeModel msj)
        {
            return SupportMessagesClass.GetMessages(msj.Sala_id);
        }

        //REGISTRA UN NUEVO MENSAJE DENTRO DE UNA SALA -- BY SOPORTE
        [HttpPost]
        [Route("support/messages/new")]
        public SupportMensajeModel NewMessage([FromBody] SupportMensajeModel msj)
        {
            return SupportMessagesClass.NewMensaje(msj.Sala_id, msj.Num_empleado, msj.Soporte_id, msj.Contenido, msj.Fecha);
        }

        //RECUPERA EL ULTIMO MENSAJE DE LA SALA SELECCIONADA
        [HttpPost]
        [Route("support/messages/salas/get-last-msj")]
        public SupportMensajeModel GetLastMsjInSala([FromBody] SupportMensajeModel msj)
        {
            return SupportMessagesClass.FindLastMessage(msj.Sala_id);
        }
    }
}