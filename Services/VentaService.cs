using Entity.DTOs;
using Entity.Interfaces;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Services
{
    public class VentaServices : IVenta
    {
        private readonly VentaspruebaContext _context;

        public VentaServices(VentaspruebaContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetVenta(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal)
        {
            var respuesta = new Respuesta();

            try
            {
                var query = from v in _context.Ventas
                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                            join p in _context.Productos on v.ProductoId equals p.ProductoId
                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                            join ct in _context.Categoria on v.CategId equals ct.CategId
                            join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                            join s in _context.Sucursals on v.SucursalId equals s.SucursalId
                            select new VentaDto
                            {
                                IdFactura = v.IdFactura,
                                NumFact = v.NumFact,
                                Fecha_Hora = v.Fecha_Hora,
                                ClienteDetalle = cl.ClienteNombre,
                                ProductoDetalle = p.ProductoDescrip,
                                ModeloDetalle = mo.ModeloDescripción,
                                CategDetalle = ct.CategNombre,
                                MarcaDetalle = ma.MarcaNombre,
                                SucursalDetalle = s.SucursalNombre,
                                Caja = v.Caja.ToString(),
                                Vendedor = v.Vendedor.ToString(),
                                Precio = v.Precio,
                                Unidades = v.Unidades,
                                EstadoId = v.EstadoId
                            };


                if (date.HasValue)
                {
                    query = query.Where(v => v.Fecha_Hora == date.Value.Date);
                }

                if (!string.IsNullOrEmpty(numFactura))
                {
                    query = query.Where(v => v.NumFact == numFactura);
                }

                if (!string.IsNullOrEmpty(vendedor))
                {
                    query = query.Where(v => v.Vendedor.Contains(vendedor));
                }

                if (precio.HasValue)
                {
                    query = query.Where(v => v.Precio <= precio);
                }

                if (estado.HasValue)
                {
                    query = query.Where(v => v.EstadoId == estado);
                }

                if (!string.IsNullOrEmpty(sucursal))
                {
                    query = query.Where(v => v.SucursalDetalle.Contains(sucursal));
                }

                respuesta.Cod = "000";
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó un error: {ex.Message}";
            }

            return respuesta;
        }
    }
}
