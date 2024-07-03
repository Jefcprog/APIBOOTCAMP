using Entity.DTOs;
using Entity.Interfaces;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Services
{
    public class ProductoServices : IProducto
    {
        private readonly VentaspruebaContext _context;

        public ProductoServices(VentaspruebaContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetListaProductos(int productoID, float precio)
        {
            var respuesta = new Respuesta();
            try
            {
                if (productoID == 0 && precio == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.EstadoId.Equals(1)
                                            select new ProductoDto
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.EstadoId,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (productoID != 0 && precio == 0)
                {
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.EstadoId.Equals(1)
                                            select new ProductoDto
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.EstadoId,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (precio != 0 && productoID == 0)
                {
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.EstadoId.Equals(1)
                                            select new ProductoDto
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.EstadoId,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (productoID != 0 && precio != 0)
                {
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.EstadoId.Equals(1)
                                            select new ProductoDto
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.EstadoId,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó un error: {ex.Message}";
            }

            return respuesta;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x => x.ProductoId).Select(x => x.ProductoId).FirstOrDefault();

                producto.ProductoId = Convert.ToInt32(query) + 1;
                producto.FechaHoraReg = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó un error: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                // Verificar si el producto existe
                var existingProducto = await _context.Productos.FindAsync(producto.ProductoId);
                if (existingProducto != null)
                {
                    // Adjuntar la entidad existente al contexto y actualizar los valores
                    _context.Entry(existingProducto).CurrentValues.SetValues(producto);
                    _context.Entry(existingProducto).State = EntityState.Modified;

                    // Guardar los cambios en la base de datos

                    producto.FechaHoraReg = DateTime.Now;
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
                respuesta.Cod = "888";
                respuesta.Mensaje = $"Se presentó un error: {ex.Message}";
            }
            return respuesta;
        }
    }
}
