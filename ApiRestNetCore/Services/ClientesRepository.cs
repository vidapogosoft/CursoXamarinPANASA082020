using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiRestNetCore.Interfaces;
using ApiRestNetCore.Models;

namespace ApiRestNetCore.Services
{
    public class ClientesRepository : IClientes
    {

        //Implemento la interfaz

        public IEnumerable<Clientes> ListClientes
        {
            get { return CargaClientes(); }
        }

        public IEnumerable<Clientes> Cliente(int IdCliente)
        {
            return CargaCliente(IdCliente);
        }


        //Accedo al contexto

        public List<Clientes> CargaClientes()
        {
            using ( var context = new DBApirestContext()) 
            {
                return context.Clientes.ToList();
            }
        
        }

        public List<Clientes> CargaCliente(int IdCliente)
        {
            using (var context = new DBApirestContext())
            {
                return context.Clientes.Where(a => a.IdCliente == IdCliente).ToList();
            }
        }


        public List<Clientes> GetClienteByIdentificacion(string Identificacion)
        {
            using (var context = new DBApirestContext())
            {
                return context.Clientes.Where(a => a.Identificacion == Identificacion).ToList();
            }
        }

        

        public void RegistroClientes(Clientes NewCliente)
        {

            using (var context = new DBApirestContext())
            {
                context.Clientes.Add(NewCliente);
                context.SaveChanges();
            }

        }

        public void UpdateRegistro(Clientes EditCliente)
        {
            using (var context = new DBApirestContext())
            {

                var cliente = context.Clientes.FirstOrDefault(a=> a.IdCliente == EditCliente.IdCliente);

                if (cliente != null)
                {
                    cliente.Identificacion = EditCliente.Identificacion;
                    cliente.Apellidos = EditCliente.Apellidos;
                    cliente.Nombres = EditCliente.Nombres;
                    cliente.FechaRegistro = DateTime.Now;

                    context.Update(cliente);
                    context.SaveChanges();
                }

            }

        }

    }
}
