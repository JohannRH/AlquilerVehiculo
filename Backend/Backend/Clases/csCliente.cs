using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Backend.Models;

namespace Backend.Clases
{
    public class csCliente
    {
        private AlquilerDBEntities db = new AlquilerDBEntities();

        public Cliente cliente { get; set; }

        public string Insertar()
        {
            try
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return "Cliente agregado correctamente.";
            }
            catch (Exception)
            {
                return "Error al agregar el cliente.";
            }
        }

        public string Actualizar()
        {
            try
            {
                Cliente cli = Consultar(cliente.id_cliente);
                if (cli == null)
                    return "Cliente no existe.";

                db.Clientes.AddOrUpdate(cliente);
                db.SaveChanges();
                return "Cliente actualizado correctamente.";
            }
            catch (Exception)
            {
                return "Error al actualizar el cliente.";
            }
        }

        public Cliente Consultar(int id)
        {
            return db.Clientes.FirstOrDefault(c => c.id_cliente == id);
        }

        public List<Cliente> ConsultarTodos()
        {
            return db.Clientes.ToList();
        }

        public string Eliminar()
        {
            try
            {
                Cliente cli = Consultar(cliente.id_cliente);
                if (cli == null)
                    return "Cliente no existe.";

                db.Clientes.Remove(cli);
                db.SaveChanges();
                return "Cliente eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el cliente: {ex.Message}";
            }
        }
    }
}