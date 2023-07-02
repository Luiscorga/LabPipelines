using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly Context _context;
        public ClienteRepository(Context context) => _context = context;

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetClienteByid(int id)
        {
            return _context.Clientes.Find(id);
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClienteAsync(Cliente cliente)
        {
            //var entity = await GetByIdAsync(id);
            if (cliente is null)
            {
                return false;
            }
            _context.Set<Cliente>().Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




