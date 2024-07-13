using Entity.DTOs;
using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace Entity.Services
{
    public class VentaServices : IVenta
    {
        private readonly VentaspruebaContext _context;
        private ControlError Log = new ControlError();

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
                            join c in _context.Cajas on v.CajaId equals c.CajaId
                            join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
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
                                CajaDetalle = c.CajaDescripcion,
                                VendedorDetalle = ve.VendedorDescripcion,
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
                    query = query.Where(v => v.VendedorDetalle.Contains(vendedor));
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "GetVenta", ex.Message);
            }

            return respuesta;
        }

        public async Task<Respuesta> GetVentaReporte(double precio)
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";

                var query = from v in _context.Ventas
                            where v.Precio >= precio
                            group v by v.Precio into newGroup
                            select new
                            {
                                Precio = newGroup.Key,
                                CantidadRegistros = newGroup.Count()

                            };

                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "GetVentaReporte", ex.Message);
            }
            return respuesta;
        }



        public async Task<Respuesta> PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura).FirstOrDefault();

                venta.IdFactura = Convert.ToInt32(query) + 1;
                venta.Fecha_Hora = DateTime.Now;

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "PostVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                var existingVenta = await _context.Ventas.FindAsync(venta.IdFactura);
                if (existingVenta != null)
                {
                    _context.Entry(existingVenta).CurrentValues.SetValues(venta);
                    _context.Entry(existingVenta).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    respuesta.Cod = "111";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }
                else
                {
                    respuesta.Cod = "888";
                    respuesta.Mensaje = "El producto no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "PutVenta", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> DeleteVenta(double id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Venta? ventaToDelete = await _context.Ventas.FirstOrDefaultAsync(x => x.IdFactura == id);

                if (ventaToDelete is not null)
                {
                    ventaToDelete.EstadoId = 0;

                    _context.Ventas.Update(ventaToDelete);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = ventaToDelete;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe una venta registrada con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaServices", "DeleteVenta", ex.Message);
            }
            return respuesta;
        }

    }
}
