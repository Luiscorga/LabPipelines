using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IOrdenRepository
    {
        Task<Orden> CreateOrdenAsync(Orden orden);
        Task<bool> DeleteOrdenAsync(Orden orden);
        Orden GetOrdenById(int id);
        IEnumerable<Orden> GetOrdenes();
        Task<bool> UpdateOrdenAsync(Orden orden);
    }
}
