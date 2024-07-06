using Entity.Models;

namespace Entity.Interfaces
{
    public interface IVenta
    {
        Task<Respuesta> GetVenta(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal);
        Task<Respuesta> GetVentaReporte(double precio);
        Task<Respuesta> PostVenta(Venta venta);
        Task<Respuesta> PutVenta(Venta venta);
    }
}