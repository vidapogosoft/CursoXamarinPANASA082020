using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using ModeloDatos;
using Clientes.BL;

using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Web.Script.Services;

namespace WebServices.Services
{
    /// <summary>
    /// Descripción breve de wsclientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsclientes : System.Web.Services.WebService
    {

        ClsBClientes clsBClientes = new ClsBClientes();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsultaCliente(string Identificacion)
        {
            List<ModeloDatos.Entidades.Clientes> cl = new List<ModeloDatos.Entidades.Clientes>();

            cl = clsBClientes.ConsultaClienteByIdentificacion(Identificacion);

            return  "{" + "\"clientes\"" + ":" +  JsonConvert.SerializeObject(cl) + "}";
        }

        [WebMethod]
        public int RegistroCliente(ModeloDatos.Clientes NewCliente)
        {
            int grabado = 0;

            grabado = clsBClientes.RegistroCliente(NewCliente);

            return grabado;

        }


        [WebMethod]
        public int RegistroCliente2(string Identificacion, string Nombres, string Apellidos)
        {
            int grabado = 0;

            ModeloDatos.Clientes cl = new ModeloDatos.Clientes();

            cl.Identificacion = Identificacion;
            cl.Nombres = Nombres;
            cl.Apellidos = Apellidos;
            cl.NombresCompletos = Nombres + " " + Apellidos;
            cl.FechaRegistro = DateTime.Now;

            grabado = clsBClientes.RegistroCliente(cl);

            return grabado;

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int RegistroCliente3(string TramaClientes)
        {
            int grabado = 0;

            JObject objJsonTrama = JObject.Parse(TramaClientes);
            JArray ClientesJson = JArray.Parse(objJsonTrama.GetValue("clientes").ToString());
            dynamic _clientesjson = ClientesJson;

            List<ModeloDatos.Clientes> clientes = new List<ModeloDatos.Clientes>();

            ModeloDatos.Clientes newcliente = new ModeloDatos.Clientes();

            foreach (var _clientes in _clientesjson)
            {
                newcliente.Identificacion = _clientes.Identificacion;
                newcliente.Apellidos = _clientes.Apellidos;
                newcliente.Nombres = _clientes.Nombres;
                newcliente.NombresCompletos = _clientes.Nombres + " " + _clientes.Apellidos;
                newcliente.FechaRegistro = DateTime.Now;

                //guardo desrializado en la lista
                clientes.Add(newcliente); //Despues en algun medtodo que reciba una lista de la entidad se envia gurdar

                //Realizo a traves del metodo de la libreria
                clsBClientes.RegistroCliente(newcliente);
                
                grabado = 1;
            }

            return grabado;

        }

        [WebMethod]
        public ModeloDatos.Clientes ConsultaCliente2(string Identificacion)
        {
            return clsBClientes.ConsultaClienteByIdentificacion2(Identificacion);
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string HelloWorldParam(int Imput)
        {
            return Imput.ToString();
        }

        public string HelloWorld2()
        {
            return "Hola a todos";
        }


    }

}
