using Entity.Models;

namespace Entity.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetCategoria();
        Task<Respuesta> GetMarca();
        Task<Respuesta> GetModelo();
        Task<Respuesta> GetSucursal();
    }
}
