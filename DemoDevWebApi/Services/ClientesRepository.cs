using DemoDevWebApi.Interfaces;
using DemoDevWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Clientes.BL;


namespace DemoDevWebApi.Services
{
    
    public class ClientesRepository : IClientesRepository
    {

        ClsBClientes clsBClientes = new ClsBClientes();

        public IEnumerable<ModeloDatos.Entidades.Clientes> GetClientes
        { get { return CargaClientes(); } }

        public IEnumerable<ModeloDatos.Entidades.Clientes> GetClienteByIdentificacion(string Identificacion)
        {
            return CargaCliente(Identificacion);
        }


        public List<ModeloDatos.Entidades.Clientes> CargaClientes()
        {
            return clsBClientes.ConsultaClientes();
        }

        public List<ModeloDatos.Entidades.Clientes> CargaCliente(string Identificacion)
        {
            return clsBClientes.ConsultaClienteByIdentificacion(Identificacion);
        }


        public void PostCliente(ModeloDatos.Clientes NewCiente)
        {
            clsBClientes.RegistroCliente(NewCiente);
        }

        public void PutCliente(ModeloDatos.Clientes UpdCiente)
        {
            clsBClientes.UpdateCliente(UpdCiente);
        }

        public void DeleteCliente(ModeloDatos.Clientes DelCliente)
        {
            clsBClientes.DeleteClientes(DelCliente);
        }
    }
}