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
    [RoutePrefix("Vehiculos")]
    public class VehiculoController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Vehiculo vehiculo)
        {
            csVehiculo obj = new csVehiculo();
            obj.vehiculo = vehiculo;
            return obj.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Vehiculo vehiculo)
        {
            csVehiculo obj = new csVehiculo();
            obj.vehiculo = vehiculo;
            return obj.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            csVehiculo obj = new csVehiculo();
            obj.vehiculo = new Vehiculo { id_vehiculo = id };
            return obj.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            csVehiculo obj = new csVehiculo();
            var resultado = obj.Consultar(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Vehiculo> ConsultarTodos()
        {
            csVehiculo obj = new csVehiculo();
            return obj.ConsultarTodos();
        }
    }
}