using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backend.Clases;
using Backend.Models;

namespace Backend.Controllers
{
    [RoutePrefix("Cliente")]
    public class ClienteController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cliente cliente)
        {
            csCliente obj = new csCliente();
            obj.cliente = cliente;
            return obj.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cliente cliente)
        {
            csCliente obj = new csCliente();
            obj.cliente = cliente;
            return obj.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            csCliente obj = new csCliente();
            obj.cliente = new Cliente { id_cliente = id };
            return obj.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            csCliente obj = new csCliente();
            var resultado = obj.Consultar(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cliente> ConsultarTodos()
        {
            csCliente obj = new csCliente();
            return obj.ConsultarTodos();
        }
    }
}