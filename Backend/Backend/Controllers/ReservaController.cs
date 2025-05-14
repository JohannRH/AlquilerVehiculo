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
    [RoutePrefix("Reserva")]
    public class ReservaController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Reserva reserva)
        {
            csReserva obj = new csReserva();
            obj.reserva = reserva;
            return obj.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Reserva reserva)
        {
            csReserva obj = new csReserva();
            obj.reserva = reserva;
            return obj.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            csReserva obj = new csReserva();
            obj.reserva = new Reserva { id_reserva = id };
            return obj.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            csReserva obj = new csReserva();
            var resultado = obj.Consultar(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Reserva> ConsultarTodos()
        {
            csReserva obj = new csReserva();
            return obj.ConsultarTodos();
        }
    }
}