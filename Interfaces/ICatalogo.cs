using Entity.Models;

namespace Entity.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetCategoria();
        Task<Respuesta> GetMarca();
        Task<Respuesta> GetModelo();
        Task<Respuesta> GetSucursal();
        Task<Respuesta> GetCiudad();
        Task<Respuesta> GetCaja();

        Task<Respuesta> PostCategoria(Categorium categoria);
        Task<Respuesta> PostMarca(Marca marca);
        Task<Respuesta> PostSucursal(Sucursal sucursal);
        Task<Respuesta> PostModelo(Modelo modelo);
        Task<Respuesta> PostCiudad(Ciudad ciudad);
        Task<Respuesta> PostCaja(Caja caja);


        Task<Respuesta> PutCategoria(Categorium categoria);
        Task<Respuesta> PutMarca(Marca marca);
        Task<Respuesta> PutSucursal(Sucursal sucursal);
        Task<Respuesta> PutModelo(Modelo modelo);
        Task<Respuesta> PutCiudad(Ciudad ciudad);
        Task<Respuesta> PutCaja(Caja caja);

        Task<Respuesta> DeleteCategoria(double id);
        Task<Respuesta> DeleteMarca(double id);
        Task<Respuesta> DeleteSucursal(double id);
        Task<Respuesta> DeleteModelo(double id);
        Task<Respuesta> DeleteCiudad(double id);
        Task<Respuesta> DeleteCaja(double id);
    }
}
