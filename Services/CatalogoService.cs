using Entity.Interfaces;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Services
{
    public class CatalogoServices : ICatalogo
    {
        private readonly VentaspruebaContext _context;

        public CatalogoServices(VentaspruebaContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCategoria()
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Categoria.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó un error: {ex.Message}";
            }

            return respuesta;
        }

            public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Marcas.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad en el Metodo: GetMarca, Error: {ex.Message}";

            }
            return respuesta;
        }

        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Modelos.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad en el Metodo: GetModelo, Error: {ex.Message}";

            }
            return respuesta;
        }

        public async Task<Respuesta> GetSucursal()
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Sucursals.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad en el Metodo: GetSucursal, Error: {ex.Message}";

            }
            return respuesta;
        }
    }
}
