using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IPrivilegiosRepository
    {
        Task<Privilegios> CreatePrivilegiosAsync(Privilegios privilegios);
        Task<bool> DeletePrivilegiosAsync(Privilegios privilegios);
        Privilegios GetPrivilegiosByid(int id);
        IEnumerable<Privilegios> GetPrivilegioss();
        Task<bool> UpdatePrivilegiosAsync(Privilegios privilegios);
    }
}
