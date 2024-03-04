using AWAppMovil.Class.Element.Profile;
using AWAppMovil.Class.Element.Registry;
using AWAppMovil.Models.Element.Profile;
using AWAppMovil.Models.Element.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AWAppMovil.Controllers.Element.Registry
{
    [EnableCors(origins: "http://localhost:3000", headers:"*", methods:"*")]

    public class ElementRegistryController : ApiController
    {
        //CONSULTA SI YA EXISTE UNA CUENTA DE ELEMENTO (MEDIANTE EL NUMERO DE EMPLEADO)
        [HttpPost]
        [Route("element/registry/search-account-by-num")]
        public ElementRegistryModel SearchAccountByNum([FromBody] ElementRegistryModel element)
        {
            return ElementRegistryClass.SearchAccountByNum(element.Num_empleado);
        }

        //CONSULTA LOS DATOS DEL ELEMENTO MEDIANTE EL NUMERO DE EMPLEADO QUE SE MUESTRAN PREVIO AL REGISTRO
        [HttpPost]
        [Route("element/registry/get-element-to-registry")]
        public ElementRegistryModel GetElementToRegistry([FromBody] ElementRegistryModel element)
        {
            return ElementRegistryClass.GetElementToRegistry(element.Num_empleado);
        }


        //CONSULTA SI YA EXISTE UNA CUENTA DE ELEMENTO (MEDIANTE EL NOMBRE)
        [HttpPost]
        [Route("element/registry/search-account-by-name")]
        public List<ElementRegistryModel> SearchAccountByName([FromBody] ElementRegistryModel element)
        {
            return ElementRegistryClass.SearchAccountByName(element.Nombre);
        }

        //CONSULTA LOS DATOS DEL ELEMENTO MEDIANTE EL NOMBRE QUE SE MUESTRAN PREVIO AL REGISTRO
        [HttpPost]
        [Route("element/registry/get-element-to-registry-by-name")]
        public ElementRegistryModel GetElementToRegistryByName([FromBody] ElementRegistryModel element)
        {
            return ElementRegistryClass.GetElementToRegistryByName(element.Nombre, element.Curp);
        }

        //CREA UNA NUEVA CUENTA DE ELEMENTO
        [HttpPost]
        [Route("element/registry/new-account")]
        public ElementRegistryModel NewAccount([FromBody] ElementRegistryModel element)
        {
            return ElementRegistryClass.CreateAccount(element.Num_empleado, element.Password, element.Status, element.Created_at);
        }

        [HttpGet]
        [Route("element/buscar-elemento-nombre-curp")]
        public ElementRegistryModel BuscarElementoNombreCurp()
        {
            return ElementRegistryClass.BuscarElementoPorNombreCurp();
        }
    }
}