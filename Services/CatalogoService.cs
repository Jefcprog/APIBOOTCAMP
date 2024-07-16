using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace Entity.Services
{
    public class CatalogoServices : ICatalogo
    {
        private readonly VentaspruebaContext _context;
        private ControlError Log = new ControlError();

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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetCategoria", ex.Message);
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetMarca", ex.Message);
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetModelo", ex.Message);

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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetSucursal", ex.Message);

            }
            return respuesta;
        }

        public async Task<Respuesta> GetCiudad()
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Ciudads.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetCiudad", ex.Message);

            }
            return respuesta;
        }

        public async Task<Respuesta> GetCaja()
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Cajas.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetCaja", ex.Message);

            }
            return respuesta;
        }

        public async Task<Respuesta> PostCategoria(Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Categoria.OrderByDescending(x => x.CategId).Select(x => x.CategId).FirstOrDefault();

                categoria.CategId = Convert.ToInt32(query) + 1;
                categoria.FechaHoraReg = DateTime.Now;

                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostMarca(Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Marcas.OrderByDescending(x => x.MarcaId).Select(x => x.MarcaId).FirstOrDefault();

                marca.MarcaId = Convert.ToInt32(query) + 1;
                marca.FechaHoraReg = DateTime.Now;

                _context.Marcas.Add(marca);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostMarca", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostSucursal(Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Sucursals.OrderByDescending(x => x.SucursalId).Select(x => x.SucursalId).FirstOrDefault();

                sucursal.SucursalId = Convert.ToInt32(query) + 1;
                sucursal.FechaHoraReg = DateTime.Now;

                _context.Sucursals.Add(sucursal);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostModelo(Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Modelos.OrderByDescending(x => x.ModeloId).Select(x => x.ModeloId).FirstOrDefault();

                modelo.ModeloId = Convert.ToInt32(query) + 1;
                modelo.FechaHoraReg = DateTime.Now;

                _context.Modelos.Add(modelo);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostCiudad(Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ciudads.OrderByDescending(x => x.CiudadId).Select(x => x.CiudadId).FirstOrDefault();

                ciudad.CiudadId = Convert.ToInt32(query) + 1;
                ciudad.FechaHoraReg = DateTime.Now;

                _context.Ciudads.Add(ciudad);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostCaja(Caja caja)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Cajas.OrderByDescending(x => x.CajaId).Select(x => x.CajaId).FirstOrDefault();

                caja.CajaId = Convert.ToInt32(query) + 1;

                _context.Cajas.Add(caja);
                await _context.SaveChangesAsync();
                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostCaja", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCategoria(Categorium categoria)
        {

            var respuesta = new Respuesta();
            try
            {
                var existingCategoria = await _context.Categoria.FindAsync(categoria.CategId);
                if (existingCategoria != null)
                {
                    _context.Entry(existingCategoria).CurrentValues.SetValues(categoria);
                    _context.Entry(existingCategoria).State = EntityState.Modified;

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
                Log.LogErrorMetodos("CatalogoServices", "PutCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutMarca(Marca marca)
        {

            var respuesta = new Respuesta();
            try
            {
                var existingMarca = await _context.Marcas.FindAsync(marca.MarcaId);
                if (existingMarca != null)
                {
                    _context.Entry(existingMarca).CurrentValues.SetValues(marca);
                    _context.Entry(existingMarca).State = EntityState.Modified;

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
                Log.LogErrorMetodos("CatalogoServices", "PutMarca", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutSucursal(Sucursal sucursal)
        {

            var respuesta = new Respuesta();
            try
            {
                var existingSucursal = await _context.Sucursals.FindAsync(sucursal.SucursalId);
                if (existingSucursal != null)
                {
                    _context.Entry(existingSucursal).CurrentValues.SetValues(sucursal);
                    _context.Entry(existingSucursal).State = EntityState.Modified;

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
                Log.LogErrorMetodos("CatalogoServices", "PutSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutModelo(Modelo modelo)
        {

            var respuesta = new Respuesta();
            try
            {
                var existingModelo = await _context.Categoria.FindAsync(modelo.ModeloId);
                if (existingModelo != null)
                {
                    _context.Entry(existingModelo).CurrentValues.SetValues(modelo);
                    _context.Entry(existingModelo).State = EntityState.Modified;

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
                Log.LogErrorMetodos("CatalogoServices", "PutModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCiudad(Ciudad ciudad)
        {

            var respuesta = new Respuesta();
            try
            {
                var existingCiudad = await _context.Ciudads.FindAsync(ciudad.CiudadId);
                if (existingCiudad != null)
                {
                    _context.Entry(existingCiudad).CurrentValues.SetValues(ciudad);
                    _context.Entry(existingCiudad).State = EntityState.Modified;

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
                Log.LogErrorMetodos("CatalogoServices", "PutCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCaja(Caja caja)
        {

            var respuesta = new Respuesta();
            try
            {
                var existingCaja = await _context.Cajas.FindAsync(caja.CajaId);
                if (existingCaja != null)
                {
                    _context.Entry(existingCaja).CurrentValues.SetValues(caja);
                    _context.Entry(existingCaja).State = EntityState.Modified;

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
                Log.LogErrorMetodos("CatalogoServices", "PutCaja", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteCategoria(Categorium categoria)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var existingCategoria = await _context.Categoria.FindAsync(categoria.CategId);
                if (existingCategoria != null)
                {
                    _context.Entry(existingCategoria).CurrentValues.SetValues(categoria);
                    _context.Entry(existingCategoria).State = EntityState.Modified;

                    categoria.EstadoId = 0;
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = categoria;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe una categoría registrada con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "DeleteCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteMarca(Marca marca)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var existingMarca = await _context.Marcas.FindAsync(marca.MarcaId);
                if (existingMarca != null)
                {
                    _context.Entry(existingMarca).CurrentValues.SetValues(marca);
                    _context.Entry(existingMarca).State = EntityState.Modified;

                    marca.EstadoId = 0;
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = marca;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe una marca registrada con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "DeleteMarca", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteSucursal(Sucursal sucursal)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var existingSucursal = await _context.Sucursals.FindAsync(sucursal.SucursalId);
                if (existingSucursal != null)
                {
                    _context.Entry(existingSucursal).CurrentValues.SetValues(sucursal);
                    _context.Entry(existingSucursal).State = EntityState.Modified;

                    sucursal.EstadoId = 0;
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = sucursal;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe una sucursal registrada con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "DeleteSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteModelo(Modelo modelo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var existingModelo = await _context.Modelos.FindAsync(modelo.ModeloId);
                if (existingModelo != null)
                {
                    _context.Entry(existingModelo).CurrentValues.SetValues(modelo);
                    _context.Entry(existingModelo).State = EntityState.Modified;

                    modelo.EstadoId = 0;
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = modelo;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe un modelo registrado con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "DeleteModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteCiudad(Ciudad ciudad)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var existingCiudad = await _context.Ciudads.FindAsync(ciudad.CiudadId);
                if (existingCiudad != null)
                {
                    _context.Entry(existingCiudad).CurrentValues.SetValues(ciudad);
                    _context.Entry(existingCiudad).State = EntityState.Modified;

                    ciudad.EstadoId = 0;
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = ciudad;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe una ciudad registrada con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "DeleteCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteCaja(Caja caja)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var existingCaja = await _context.Cajas.FindAsync(caja.CajaId);
                if (existingCaja != null)
                {
                    _context.Entry(existingCaja).CurrentValues.SetValues(caja);
                    _context.Entry(existingCaja).State = EntityState.Modified;

                    caja.EstadoId = 0;
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = caja;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe un cajero registrado con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "DeleteCaja", ex.Message);
            }
            return respuesta;
        }
    }
}
