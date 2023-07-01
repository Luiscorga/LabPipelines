using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IEstadosOrdenRepository
    {
        Task<EstadosOrden> CreateEstadosOrdenAsync(EstadosOrden estadosOrden);
        Task<bool> DeleteEstadosOrdenAsync(EstadosOrden estadosOrden);
        EstadosOrden GetEstadosOrdenByid(int id);
        IEnumerable<EstadosOrden> GetEstadosOrdens();
        Task<bool> UpdateEstadosOrdenAsync(EstadosOrden estadosOrden);
    }
}
