using Entity.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Entity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            this._cliente = cliente;
        }

        [HttpGet]
        [Route("GetListaClientes")]
        public async Task<Respuesta> GetListaClientes(double clienteID, string? clientenombre, double cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.GetListaClientes(clienteID, clientenombre, cedula);
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PostCliente(cliente);
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PutCliente(cliente);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}