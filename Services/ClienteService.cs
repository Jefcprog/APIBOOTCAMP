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

        public async Task<Respuesta> GetListaClientes(double clienteID, string? clienteNombre, double cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = from cl in _context.Clientes
                                where cl.EstadoId.Equals(1)
                                select new ClienteDto
                                {
                                    ClienteId = cl.ClienteId,
                                    ClienteNombre = cl.ClienteNombre,
                                    Cedula = cl.Cedula,
                                    Estado = cl.EstadoId,
                                    FechaHoraReg = cl.FechaHoraReg
                                };

                // Filtrar según las combinaciones posibles de los parámetros
                if (clienteID != 0 && !string.IsNullOrEmpty(clienteNombre) && cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteId == clienteID && cl.ClienteNombre.Contains(clienteNombre) && cl.Cedula == cedula).ToListAsync();
                }
                else if (clienteID != 0 && !string.IsNullOrEmpty(clienteNombre))
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteId == clienteID && cl.ClienteNombre.Contains(clienteNombre)).ToListAsync();
                }
                else if (clienteID != 0 && cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteId == clienteID && cl.Cedula == cedula).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(clienteNombre) && cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteNombre.Contains(clienteNombre) && cl.Cedula == cedula).ToListAsync();
                }
                else if (clienteID != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteId == clienteID).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(clienteNombre))
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteNombre.Contains(clienteNombre)).ToListAsync();
                }
                else if (cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.Cedula == cedula).ToListAsync();
                }
                else
                {
                    respuesta.Data = await query.ToListAsync();
                }

                respuesta.Cod = "000";
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ClienteServices", "GetListaClientes", ex.Message);
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
                Log.LogErrorMetodos("ClienteServices", "PostCliente", ex.Message);
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
                Log.LogErrorMetodos("ClienteServices", "PutCliente", ex.Message);
            }
            return respuesta;
        }
    }
}
