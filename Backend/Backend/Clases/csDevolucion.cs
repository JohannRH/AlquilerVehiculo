using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Backend.Models;

namespace Backend.Clases
{
    public class csDevolucion
    {
        private AlquilerDBEntities db = new AlquilerDBEntities();

        public Devolucione devolucion { get; set; }

        public string Insertar()
        {
            try
            {
                db.Devoluciones.Add(devolucion);
                db.SaveChanges();
                return "Devolución registrada correctamente.";
            }
            catch (Exception)
            {
                return "Error al registrar la devolución.";
            }
        }

        public string Actualizar()
        {
            try
            {
                Devolucione d = Consultar(devolucion.id_devolucion);
                if (d == null)
                    return "Devolución no existe.";

                db.Devoluciones.AddOrUpdate(devolucion);
                db.SaveChanges();
                return "Devolución actualizada correctamente.";
            }
            catch (Exception)
            {
                return "Error al actualizar la devolución.";
            }
        }

        public Devolucione Consultar(int id)
        {
            return db.Devoluciones.FirstOrDefault(d => d.id_devolucion == id);
        }

        public List<Devolucione> ConsultarTodos()
        {
            return db.Devoluciones.ToList();
        }

        public string Eliminar()
        {
            try
            {
                Devolucione d = Consultar(devolucion.id_devolucion);
                if (d == null)
                    return "Devolución no existe.";

                db.Devoluciones.Remove(d);
                db.SaveChanges();
                return "Devolución eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la devolución: {ex.Message}";
            }
        }
    }
}