using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly Context _context;
        public UsuarioRepository(Context context) => _context = context;

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetUsuarioByid(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsuarioAsync(Usuario usuario)
        {
            //var entity = await GetByIdAsync(id);
            if (usuario is null)
            {
                return false;
            }
            _context.Set<Usuario>().Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




