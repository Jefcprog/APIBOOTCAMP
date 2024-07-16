using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace Entity.Services
{
    public class VendedorServices : IVendedor
    {
        private readonly VentaspruebaContext _context;
        private ControlError Log = new ControlError();

        public VendedorServices(VentaspruebaContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetVendedor()
        {
            var respuesta = new Respuesta();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Vendedors.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VendedorServices", "GetVendedor", ex.Message);
            }

            return respuesta;
        }


        public async Task<Respuesta> PostVendedor(Vendedor vendedor)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Vendedors.OrderByDescending(x => x.VendedorId).Select(x => x.VendedorId).FirstOrDefault();

                vendedor.VendedorId = Convert.ToInt32(query) + 1;

                _context.Vendedors.Add(vendedor);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VendedorServices", "PostVendedor", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutVendedor(Vendedor vendedor)
        {
            var respuesta = new Respuesta();
            try
            {
                var existingVendedor = await _context.Vendedors.FindAsync(vendedor);
                if (existingVendedor != null)
                {
                    _context.Entry(existingVendedor).CurrentValues.SetValues(vendedor);
                    _context.Entry(existingVendedor).State = EntityState.Modified;

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
                Log.LogErrorMetodos("VendedorServices", "PutVendedor", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> DeleteVendedor(Vendedor vendedor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var existingVendedor = await _context.Vendedors.FindAsync(vendedor.VendedorId);

                if (existingVendedor != null)
                {
                    _context.Entry(existingVendedor).CurrentValues.SetValues(vendedor);
                    _context.Entry(existingVendedor).State = EntityState.Modified;

                    vendedor.EstadoId = 0;
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "111";
                    respuesta.Mensaje = "Se ha eliminado correctamente";
                }
                else
                {
                    respuesta.Cod = "888";
                    respuesta.Mensaje = "El vendedor no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VendedorServices", "DeleteVendedor", ex.Message);
            }
            return respuesta;
        }


    }
}