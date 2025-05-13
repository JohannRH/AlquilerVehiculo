using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Backend.Models;

namespace Backend.Clases
{
    public class csVehiculo
    {
        private AlquilerDBEntities db = new AlquilerDBEntities();

        public Vehiculo vehiculo { get; set; }

        public string Insertar()
        {
            try
            {
                db.Vehiculos.Add(vehiculo);
                db.SaveChanges();
                return "Vehículo agregado correctamente";
            }
            catch (Exception)
            {
                return "Error al agregar el vehículo";
            }
        }

        public string Actualizar()
        {
            try
            {
                var existente = Consultar(vehiculo.id_vehiculo);
                if (existente == null)
                    return "Vehículo no encontrado";

                db.Vehiculos.AddOrUpdate(vehiculo);
                db.SaveChanges();
                return "Vehículo actualizado correctamente";
            }
            catch (Exception)
            {
                return "Error al actualizar el vehículo";
            }
        }

        public Vehiculo Consultar(int id)
        {
            return db.Vehiculos.FirstOrDefault(v => v.id_vehiculo == id);
        }

        public List<Vehiculo> ConsultarTodos()
        {
            return db.Vehiculos.ToList();
        }

        public string Eliminar()
        {
            try
            {
                var existente = Consultar(vehiculo.id_vehiculo);
                if (existente == null)
                    return "Vehículo no encontrado";

                db.Vehiculos.Remove(existente);
                db.SaveChanges();
                return "Vehículo eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }
    }
}