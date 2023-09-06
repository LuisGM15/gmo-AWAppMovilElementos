using AWAppMovil.Class.Element;
using AWAppMovil.Models.Element.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAppMovil.Controllers.Element
{
    public class ElementMessagesController : ApiController
    {
        [HttpGet]//OBTIENE TODOS LOS TEMAS
        [Route("element/messages/themes/get")]
        public List<ElementTemaModel> GetThemes()
        {
            return ElementMessagesClass.GetThemes();
        }

        [HttpPost]//OBTIENE TODAS LAS SALAS
        [Route("element/messages/salas/get")]
        public List<ElementSalaModel> GetSalas([FromBody] ElementSalaModel sala)
        {
            return ElementMessagesClass.GetSalas(sala.Num_empleado);
        }

        [HttpPost]//BUSCA LA EXISTENCIA DE UNA SALA 
        [Route("element/mesagges/salas/find")]
        public ElementSalaModel FindSala([FromBody] ElementSalaModel sala)
        {
            return ElementMessagesClass.FindSala(sala.Num_empleado, sala.Tema_id);
        }

        [HttpPost]
        [Route("element/messages/salas/get-last-msj")]
        public ElementMensajeModel FindLastMsj([FromBody] ElementMensajeModel msj)
        {
            return ElementMessagesClass.FindLastMessage(msj.Sala_id);
        }

        [HttpPost]//OBTIENE TODOS LOS MENSAJES PERTENECIENTES A UNA SALA
        [Route("element/messages/get-all")]
        public List<ElementMensajeModel> GetMsjs([FromBody] ElementMensajeModel msj)
        {
            return ElementMessagesClass.GetMsjs(msj.Sala_id);
        }

        [HttpPost]//REGISTRA UNA NUEVA SALA
        [Route("element/messages/sala/new")]
        public ElementSalaModel NewSala([FromBody] ElementSalaModel sala)
        {
            return ElementMessagesClass.NewSala(sala.Tema_id, sala.Num_empleado, sala.Fecha);
        }

        [HttpPost]//REGISTRA UN NUEVO MENSAJE
        [Route("element/messages/new")]
        public ElementMensajeModel NewMensaje([FromBody] ElementMensajeModel mensaje)
        {
            return ElementMessagesClass.NewMensaje(mensaje.Sala_id, mensaje.Num_empleado, mensaje.Soporte_id, mensaje.Contenido, mensaje.Fecha);
        }
    }
}