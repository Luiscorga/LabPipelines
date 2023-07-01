using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IDetalleEventoRepository
    {
        Task<DetalleEvento> CreateDetalleEventoAsync(DetalleEvento detalleEvento);
        Task<bool> DeleteDetalleEventoAsync(DetalleEvento detalleEvento);
        DetalleEvento GetDetalleEventoByid(int id);
        IEnumerable<DetalleEvento> GetDetalleEventos();
        Task<bool> UpdateDetalleEventoAsync(DetalleEvento detalleEvento);
    }
}
