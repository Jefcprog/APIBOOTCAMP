using Entity.Models;

namespace Entity.Interfaces
{
    public interface IVendedor
    {
        Task<Respuesta> GetVendedor();
        Task<Respuesta> PostVendedor(Vendedor vendedor);
        Task<Respuesta> PutVendedor(Vendedor vendedor);
        Task<Respuesta> DeleteVendedor(Vendedor vendedor);

    }
}