using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IEstadoProductoProductoRepository
    {
        Task<EstadoProductoProducto> CreateEstadoProductoProductoAsync(EstadoProductoProducto EstadoProductoProducto);
        Task<bool> DeleteEstadoProductoProductoAsync(EstadoProductoProducto EstadoProductoProducto);
        EstadoProductoProducto GetEstadoProductoProductoByid(int id);
        IEnumerable<EstadoProductoProducto> GetEstadoProductoProductos();
        Task<bool> UpdateEstadoProductoProductoAsync(EstadoProductoProducto EstadoProductoProducto);
    }
}
