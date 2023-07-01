using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IEstadoProductoRepository
    {
        Task<EstadoProducto> CreateEstadoProductoAsync(EstadoProducto EstadoProducto);
        Task<bool> DeleteEstadoProductoAsync(EstadoProducto EstadoProducto);
        EstadoProducto GetEstadoProductoByid(int id);
        IEnumerable<EstadoProducto> GetEstadoProductos();
        Task<bool> UpdateEstadoProductoAsync(EstadoProducto EstadoProducto);
    }
}
