using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : Controller
    {
        private readonly IVendedor _vendedor;
        private ControlError Log = new ControlError();

        public VendedorController(IVendedor vendedor)
        {
            this._vendedor = vendedor;
        }

        [HttpGet]
        [Route("GetVendedor")]
        public async Task<Respuesta> GetVendedor()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _vendedor.GetVendedor();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorController", "GetVendedor", ex.Message);
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostVendedor")]
        public async Task<Respuesta> PostVendedor([FromBody] Vendedor vendedor)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _vendedor.PostVendedor(vendedor);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorController", "PostVendedor", ex.Message);
            }

            return respuesta;
        }
        [HttpPut]
        [Route("PutVendedor")]
        public async Task<Respuesta> PutVendedor([FromBody] Vendedor vendedor)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _vendedor.PutVendedor(vendedor);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorController", "PutVendedor", ex.Message);
            }

            return respuesta;
        }
        [HttpPut]
        [Route("DeleteVendedor")]
        public async Task<Respuesta> DeleteVendedor([FromBody] Vendedor vendedor)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _vendedor.DeleteVendedor(vendedor);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorController", "DeleteVendedor", ex.Message);
            }

            return respuesta;
        }
    }
}
