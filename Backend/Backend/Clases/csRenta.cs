using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Backend.Models;

namespace Backend.Clases
{
    public class csRenta
    {
        private AlquilerDBEntities db = new AlquilerDBEntities();

        public Renta renta { get; set; }

        public string Insertar()
        {
            try
            {
                db.Rentas.Add(renta);
                db.SaveChanges();
                return "Renta registrada correctamente.";
            }
            catch (Exception)
            {
                return "Error al registrar la renta.";
            }
        }

        public string Actualizar()
        {
            try
            {
                Renta r = Consultar(renta.id_renta);
                if (r == null)
                    return "Renta no existe.";

                db.Rentas.AddOrUpdate(renta);
                db.SaveChanges();
                return "Renta actualizada correctamente.";
            }
            catch (Exception)
            {
                return "Error al actualizar la renta.";
            }
        }

        public Renta Consultar(int id)
        {
            return db.Rentas.FirstOrDefault(r => r.id_renta == id);
        }

        public List<Renta> ConsultarTodos()
        {
            return db.Rentas.ToList();
        }

        public string Eliminar()
        {
            try
            {
                Renta r = Consultar(renta.id_renta);
                if (r == null)
                    return "Renta no existe.";

                db.Rentas.Remove(r);
                db.SaveChanges();
                return "Renta eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la renta: {ex.Message}";
            }
        }
    }
}