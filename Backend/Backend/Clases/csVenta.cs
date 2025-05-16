using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Backend.Models;

namespace Backend.Clases
{
    public class csVenta
    {
        private AlquilerDBEntities db = new AlquilerDBEntities();

        public Venta venta { get; set; }

        public string Insertar()
        {
            try
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
                return "Venta registrada correctamente.";
            }
            catch (Exception)
            {
                return "Error al registrar la venta.";
            }
        }

        public string Actualizar()
        {
            try
            {
                Venta v = Consultar(venta.id_venta);
                if (v == null)
                    return "Venta no existe.";

                db.Ventas.AddOrUpdate(venta);
                db.SaveChanges();
                return "Venta actualizada correctamente.";
            }
            catch (Exception)
            {
                return "Error al actualizar la venta.";
            }
        }

        public Venta Consultar(int id)
        {
            return db.Ventas.FirstOrDefault(v => v.id_venta == id);
        }

        public List<Venta> ConsultarTodos()
        {
            return db.Ventas.ToList();
        }

        public string Eliminar()
        {
            try
            {
                Venta v = Consultar(venta.id_venta);
                if (v == null)
                    return "Venta no existe.";

                db.Ventas.Remove(v);
                db.SaveChanges();
                return "Venta eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la venta: {ex.Message}";
            }
        }
    }
}