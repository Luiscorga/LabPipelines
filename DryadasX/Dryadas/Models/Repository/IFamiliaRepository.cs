using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IFamiliaRepository
    {
        Task<Familia> CreateFamiliaAsync(Familia familia);
        Task<bool> DeleteFamiliaAsync(Familia familia);
        Familia GetFamiliaByid(int id);
        IEnumerable<Familia> GetFamilias();
        Task<bool> UpdateFamiliaAsync(Familia familia);
    }
}
