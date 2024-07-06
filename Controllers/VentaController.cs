using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : Controller
    {
        private readonly IVenta _venta;
        private ControlError Log = new ControlError();

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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "GetVenta", ex.Message);                
            }

            return respuesta;
        }

        [HttpGet]
        [Route("GetVentaReporte")]
        public async Task<Respuesta> GetVentaReporte(double precio)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVentaReporte(precio);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "GetVentaReporte", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "PostVenta", ex.Message);
            }

            return respuesta;
        }
        [HttpPut]
        [Route("PutVenta")]
        public async Task<Respuesta> PutVenta([FromBody] Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PutVenta(venta);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "PutVenta", ex.Message);
            }

            return respuesta;
        }
    }
}