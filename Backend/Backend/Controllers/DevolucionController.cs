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
    [RoutePrefix("Devolucion")]
    public class DevolucionController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Devolucione devolucion)
        {
            csDevolucion obj = new csDevolucion();
            obj.devolucion = devolucion;
            return obj.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Devolucione devolucion)
        {
            csDevolucion obj = new csDevolucion();
            obj.devolucion = devolucion;
            return obj.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            csDevolucion obj = new csDevolucion();
            obj.devolucion = new Devolucione { id_devolucion = id };
            return obj.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            csDevolucion obj = new csDevolucion();
            var resultado = obj.Consultar(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Devolucione> ConsultarTodos()
        {
            csDevolucion obj = new csDevolucion();
            return obj.ConsultarTodos();
        }
    }
}