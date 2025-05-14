using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Backend.Models;

namespace Backend.Clases
{
    public class csReserva
    {
        private AlquilerDBEntities db = new AlquilerDBEntities();

        public Reserva reserva { get; set; }

        public string Insertar()
        {
            try
            {
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return "Reserva registrada correctamente.";
            }
            catch (Exception)
            {
                return "Error al registrar la reserva.";
            }
        }

        public string Actualizar()
        {
            try
            {
                Reserva r = Consultar(reserva.id_reserva);
                if (r == null)
                    return "Reserva no existe.";

                db.Reservas.AddOrUpdate(reserva);
                db.SaveChanges();
                return "Reserva actualizada correctamente.";
            }
            catch (Exception)
            {
                return "Error al actualizar la reserva.";
            }
        }

        public Reserva Consultar(int id)
        {
            return db.Reservas.FirstOrDefault(r => r.id_reserva == id);
        }

        public List<Reserva> ConsultarTodos()
        {
            return db.Reservas.ToList();
        }

        public string Eliminar()
        {
            try
            {
                Reserva r = Consultar(reserva.id_reserva);
                if (r == null)
                    return "Reserva no existe.";

                db.Reservas.Remove(r);
                db.SaveChanges();
                return "Reserva eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la reserva: {ex.Message}";
            }
        }
    }
}