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
    [RoutePrefix("TipoVehiculo")]
    public class TipoVehiculoController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TiposVehiculo tipoVehiculo)
        {
            csTipoVehiculo obj = new csTipoVehiculo();
            obj.tipoVehiculo = tipoVehiculo;
            return obj.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] TiposVehiculo tipoVehiculo)
        {
            csTipoVehiculo obj = new csTipoVehiculo();
            obj.tipoVehiculo = tipoVehiculo;
            return obj.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            csTipoVehiculo obj = new csTipoVehiculo();
            obj.tipoVehiculo = new TiposVehiculo { id_tipo = id };
            return obj.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            csTipoVehiculo obj = new csTipoVehiculo();
            var resultado = obj.Consultar(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<TiposVehiculo> ConsultarTodos()
        {
            csTipoVehiculo obj = new csTipoVehiculo();
            return obj.ConsultarTodos();
        }
    }
}