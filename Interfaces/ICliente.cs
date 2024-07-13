using Entity.Models;

namespace Entity.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> GetListaClientes(double clienteID, string? clientenombre, double cedula);
        Task<Respuesta> PostCliente(Cliente cliente);
        Task<Respuesta> PutCliente(Cliente cliente);
        Task<Respuesta> DeleteCliente(double id);
    }
}
