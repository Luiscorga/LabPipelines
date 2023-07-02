using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> CreateClienteAsync(Cliente cliente);
        Task<bool> DeleteClienteAsync(Cliente cliente);
        Cliente GetClienteByid(int id);
        IEnumerable<Cliente> GetClientes();
        Task<bool> UpdateClienteAsync(Cliente cliente);
    }
}
