using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class UsuarioClienteRepository : IUsuarioClienteRepository
    {
        protected readonly Context _context;
        public UsuarioClienteRepository(Context context) => _context = context;

        public IEnumerable<UsuarioCliente> GetUsuarioClientes()
        {
            return _context.UsuarioClientes.ToList();
        }

        public UsuarioCliente GetUsuarioClienteByid(int id)
        {
            return _context.UsuarioClientes.Find(id);
        }

        public async Task<UsuarioCliente> CreateUsuarioClienteAsync(UsuarioCliente usuarioCliente)
        {
            await _context.Set<UsuarioCliente>().AddAsync(usuarioCliente);
            await _context.SaveChangesAsync();
            return usuarioCliente;
        }

        public async Task<bool> UpdateUsuarioClienteAsync(UsuarioCliente usuarioCliente)
        {
            _context.Entry(usuarioCliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsuarioClienteAsync(UsuarioCliente usuarioCliente)
        {
            //var entity = await GetByIdAsync(id);
            if (usuarioCliente is null)
            {
                return false;
            }
            _context.Set<UsuarioCliente>().Remove(usuarioCliente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




