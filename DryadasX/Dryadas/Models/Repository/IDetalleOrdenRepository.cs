using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IDetalleOrdenRepository
    {
        Task<DetalleOrden> CreateDetalleOrdenAsync(DetalleOrden detalleOrden);
        Task<bool> DeleteDetalleOrdenAsync(DetalleOrden detalleOrden);
        DetalleOrden GetDetalleOrdenById(int id);
        IEnumerable<DetalleOrden> GetDetalleOrdenes();
        Task<bool> UpdateDetalleOrdenAsync(DetalleOrden detalleOrden);
    }
}
