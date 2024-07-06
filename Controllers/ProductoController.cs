using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Entity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;
        private ControlError Log = new ControlError();
        public ProductoController(IProducto producto)
        {
            this._producto = producto;
        }

        [HttpGet]
        [Route("GetListaProductos")]
        public async Task<Respuesta> GetListaProductos(int productoID, float precio)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.GetListaProductos(productoID, precio);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "GetListaProductos", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PutProducto", ex.Message);
            }
            return respuesta;
        }
    }
}