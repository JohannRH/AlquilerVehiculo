using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Backend.Models;

namespace Backend.Clases
{
    public class csTipoVehiculo
    {
        private AlquilerDBEntities db = new AlquilerDBEntities();

        public TiposVehiculo tipoVehiculo { get; set; }

        public string Insertar()
        {
            try
            {
                db.TiposVehiculos.Add(tipoVehiculo);
                db.SaveChanges();
                return "Tipo de vehículo agregado correctamente";
            }
            catch (Exception)
            {
                return "Error al agregar el tipo de vehículo";
            }
        }

        public string Actualizar()
        {
            try
            {
                TiposVehiculo existente = Consultar(tipoVehiculo.id_tipo);
                if (existente == null)
                    return "Tipo de vehículo no encontrado";

                db.TiposVehiculos.AddOrUpdate(tipoVehiculo);
                db.SaveChanges();
                return "Tipo de vehículo actualizado correctamente";
            }
            catch (Exception)
            {
                return "Error al actualizar el tipo de vehículo";
            }
        }

        public TiposVehiculo Consultar(int id)
        {
            return db.TiposVehiculos.FirstOrDefault(t => t.id_tipo == id);
        }

        public List<TiposVehiculo> ConsultarTodos()
        {
            return db.TiposVehiculos.ToList();
        }

        public string Eliminar()
        {
            try
            {
                TiposVehiculo existente = Consultar(tipoVehiculo.id_tipo);
                if (existente == null)
                    return "Tipo de vehículo no encontrado";

                db.TiposVehiculos.Remove(existente);
                db.SaveChanges();
                return "Tipo de vehículo eliminado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }
    }
}