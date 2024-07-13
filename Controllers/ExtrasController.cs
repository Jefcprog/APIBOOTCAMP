using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtrasController : Controller
    {

        private ControlError Log = new ControlError();
        private PokeApi pokeApi = new PokeApi();
        private ChuckNorrisApi chuknorrisApi = new ChuckNorrisApi();
        private readonly IConfiguration _configuration;

        public ExtrasController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPokeApi").Value!;      
                respuesta = await pokeApi.GetPokeApi(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorrisApi")]
        public async Task<Respuesta> GetChuckNorrisApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckNorrisApi").Value!;
                respuesta = await chuknorrisApi.GetChuckNorrisApi(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetChuckNorrisApi", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCNARandom_Category")]
        public async Task<Respuesta> GetCNARandom_Category(string categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlCNARandom_Category").Value!;
                respuesta = await chuknorrisApi.GetCNARandom_Category(url, categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetCNARandom_Category", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCNACategory")]
        public async Task<Respuesta> GetCNACategory()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlCNACategory").Value!;
                respuesta = await chuknorrisApi.GetCNACategory(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetChuckNorrisApi", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCNAQuery")]
        public async Task<Respuesta> GetCNAQuery(string texto)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlCNAQuery").Value!;
                respuesta = await chuknorrisApi.GetCNAQuery(url, texto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetCNAQuery", ex.Message);
            }
            return respuesta;
        }
    }
}

