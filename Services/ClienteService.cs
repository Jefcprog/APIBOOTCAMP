using Entity.DTOs;
using Entity.Interfaces;
using Entity.Models;
using Entity.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace Entity.Services
{
    public class ClienteServices : ICliente
    {
        private readonly VentaspruebaContext _context;
        private ControlError Log = new ControlError();

        public ClienteServices(VentaspruebaContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetListaClientes(double clienteID, string? clientenombre, double cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                if (clienteID == 0 || clientenombre == null || cedula == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from cl in _context.Clientes
                                            where cl.EstadoId.Equals(1)
                                            select new  ClienteDto
                                            {
                                                ClienteId = cl.ClienteId,
                                                ClienteNombre = cl.ClienteNombre,
                                                Cedula = cl.Cedula,
                                                Estado = cl.EstadoId,
                                                FechaHoraReg = cl.FechaHoraReg

                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }

                else if (clienteID != 0 || clientenombre != null || cedula != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from cl in _context.Clientes
                                            where cl.EstadoId.Equals(1)
                                            select new ClienteDto
                                            {
                                                ClienteId = cl.ClienteId,
                                                ClienteNombre = cl.ClienteNombre,
                                                Cedula = cl.Cedula,
                                                Estado = cl.EstadoId,
                                                FechaHoraReg = cl.FechaHoraReg

                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("GetListaClientes", ex.Message);
            }

            return respuesta;
        }

        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes.OrderByDescending(x => x.ClienteId).Select(x => x.ClienteId).FirstOrDefault();

                cliente.ClienteId = Convert.ToInt32(query) + 1;
                cliente.FechaHoraReg = DateTime.Now;

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("PostCliente", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var existingCliente = await _context.Clientes.FindAsync(cliente.ClienteId);
                if (existingCliente != null)
                {
                    _context.Entry(existingCliente).CurrentValues.SetValues(cliente);
                    _context.Entry(existingCliente).State = EntityState.Modified;


                    cliente.FechaHoraReg = DateTime.Now;
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
                Log.LogErrorMetodos("PutCliente", ex.Message);
            }
            return respuesta;
        }
    }
}
