using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();

        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        [HttpGet]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCategoria();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetMarca")]
        public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetMarca();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetModelo")]
        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetModelo();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetSucursal")]
        public async Task<Respuesta> GetSucursal()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetSucursal();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetSucursal", ex.Message);
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetCiudad")]
        public async Task<Respuesta> GetCiudad()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCiudad();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCiudad", ex.Message);
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetCaja")]
        public async Task<Respuesta> GetCaja()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCaja();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCaja", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostVenta", ex.Message);
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostMarca")]
        public async Task<Respuesta> PostMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostMarca(marca);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostMarca", ex.Message);
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostSucursal")]
        public async Task<Respuesta> PostSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostSucursal(sucursal);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostSucursal", ex.Message);
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostModelo")]
        public async Task<Respuesta> PostModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostModelo(modelo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostModelo", ex.Message);
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostCiudad")]
        public async Task<Respuesta> PostCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCiudad(ciudad);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCiudad", ex.Message);
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostCaja")]
        public async Task<Respuesta> PostCaja([FromBody] Caja caja)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCaja(caja);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCaja", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCategoria", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutMarca")]
        public async Task<Respuesta> PutMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutMarca(marca);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutMarca", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutSucursal")]
        public async Task<Respuesta> PutSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutSucursal(sucursal);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutSucursal", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutModelo")]
        public async Task<Respuesta> PutModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutModelo(modelo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutModelo", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutCiudad")]
        public async Task<Respuesta> PutCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCiudad(ciudad);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCiudad", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutCaja")]
        public async Task<Respuesta> PutCaja([FromBody] Caja caja)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCaja(caja);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCaja", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("DeleteCategoria")]
        public async Task<Respuesta> DeleteCategoria(double id)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.DeleteCategoria(id);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "DeleteCategoria", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("DeleteMarca")]
        public async Task<Respuesta> DeleteMarca(double id)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.DeleteMarca(id);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "DeleteMarca", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("DeleteSucursal")]
        public async Task<Respuesta> DeleteSucursal(double id)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.DeleteSucursal(id);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "DeleteSucursal", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("DeleteModelo")]
        public async Task<Respuesta> DeleteModelo(double id)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.DeleteModelo(id);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "DeleteModelo", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("DeleteCiudad")]
        public async Task<Respuesta> DeleteCiudad(double id)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.DeleteCiudad(id);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "DeleteCiudad", ex.Message);
            }

            return respuesta;
        }

        [HttpPut]
        [Route("DeleteCaja")]
        public async Task<Respuesta> DeleteCaja(double id)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.DeleteCaja(id);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "DeleteCaja", ex.Message);
            }

            return respuesta;
        }
    }
}