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
    [RoutePrefix("Renta")]
    public class RentaController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Renta renta)
        {
            csRenta obj = new csRenta();
            obj.renta = renta;
            return obj.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Renta renta)
        {
            csRenta obj = new csRenta();
            obj.renta = renta;
            return obj.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            csRenta obj = new csRenta();
            obj.renta = new Renta { id_renta = id };
            return obj.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            csRenta obj = new csRenta();
            var resultado = obj.Consultar(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Renta> ConsultarTodos()
        {
            csRenta obj = new csRenta();
            return obj.ConsultarTodos();
        }
    }
}