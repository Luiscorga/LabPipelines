using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IEstadoRepository
    {
        Task<Estado> CreateEstadoAsync(Estado estado);
        Task<bool> DeleteEstadoAsync(Estado estado);
        Estado GetEstadoByid(int id);
        IEnumerable<Estado> GetEstados();
        Task<bool> UpdateEstadoAsync(Estado estado);
    }
}
