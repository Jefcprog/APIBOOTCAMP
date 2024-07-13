using Entity.DTOs;
using Entity.Models;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Entity.Utilitarios
{
    public class ChuckNorrisApi
    {
        private ControlError log = new ControlError();

        public async Task<Respuesta> GetChuckNorrisApi(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisApiDto>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";


            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrisApi", "GetChuckNorrisApi", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetCNARandom_Category(string url,string categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?query={categoria}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<CNARandom_CategoryDto>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";


            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrisApi", "GetCNARandom_Category", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetCNACategory(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<List<string>>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrisApi", "GetCNACategory", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetCNAQuery(string url, string texto)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?query={texto}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<CNAQueryDto>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";


            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrisApi", "GetCNAQuery", ex.Message);
            }
            return respuesta;
        }
    }
}
