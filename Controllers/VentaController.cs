using Entity.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : Controller
    {
        private readonly IVenta _venta;

        public VentaController(IVenta venta)
        {
            this._venta = venta;
        }

        [HttpGet]
        [Route("GetVenta")]
        public async Task<Respuesta> GetVenta(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVenta(numFactura,date, vendedor, precio, estado, sucursal);
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }
        [HttpPost]
        [Route("PostVenta")]
        public async Task<Respuesta> PostVenta([FromBody] Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PostVenta(venta);
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }
    }
}