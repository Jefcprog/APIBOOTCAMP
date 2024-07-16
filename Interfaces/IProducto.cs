using Entity.Models;

namespace Entity.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> GetListaProductos(int productoID, float precio);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
        Task<Respuesta> DeleteProducto(Producto producto);
    }
}
