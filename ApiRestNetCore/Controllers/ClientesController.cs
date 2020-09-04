using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using ApiRestNetCore.Interfaces;
using ApiRestNetCore.Models;

namespace ApiRestNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _IClientes;

        public ClientesController(IClientes IClientes)
        {
            _IClientes = IClientes;
        }

        // GET: api/<ClientesController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IClientes.ListClientes);
        }


        [HttpGet]
        [Route("clientes2")]
        public IActionResult Get2()
        {
            return Ok(_IClientes.ListClientes);
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ClientesController>/5
        [HttpGet("{IdCliente}", Name = "Get")]
        public IActionResult GetCliente(int IdCliente)
        {
            return Ok(_IClientes.Cliente(IdCliente));
        }


        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ClientesController>

        [HttpPost]
        public IActionResult RegisterCliente([FromBody] Clientes NewCliente)
        {
            try
            {
                if (NewCliente == null || !ModelState.IsValid)
                {
                    return BadRequest("Problemas en el registro de clientes");
                }

                _IClientes.RegistroClientes(NewCliente);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(NewCliente);
        }

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}

        // PUT api/<ClientesController>/5
        [HttpPut]
        public IActionResult EditRegistro([FromBody] Clientes EditCliente)
        {

            try
            {

                if (EditCliente == null || !ModelState.IsValid)
                {
                    //return BadRequest("Problemas en la edicion de datos");
                    return StatusCode(409,"Error");
                }

                _IClientes.UpdateRegistro(EditCliente);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //return NoContent();

            return StatusCode(200, "Actualizado");

        }

        //////[HttpPut("{id}")]
        //////public void Put(int id, [FromBody] string value)
        //////{
        //////}

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
