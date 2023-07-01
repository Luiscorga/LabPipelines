using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class AutenticacionRepository : IAutenticacionRepository
    {
        protected readonly Context _context;
        public AutenticacionRepository(Context context) => _context = context;

        public IEnumerable<Usuario> GetAutenticacions()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetAutenticacionByid(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public async Task<Usuario> CreateAutenticacionAsync(Usuario autenticacion)
        {
            await _context.Set<Usuario>().AddAsync(autenticacion);
            await _context.SaveChangesAsync();
            return autenticacion;
        }

        public async Task<bool> UpdateAutenticacionAsync(Usuario autenticacion)
        {
            _context.Entry(autenticacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAutenticacionAsync(Usuario autenticacion)
        {
            //var entity = await GetByIdAsync(id);
            if (autenticacion is null)
            {
                return false;
            }
            _context.Set<Usuario>().Remove(autenticacion);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool Login(string usuarioN, string password)
        {
            bool loginPass = false;
            Usuario usuario = _context.Usuarios.FirstOrDefault(e => e.PNombre == usuarioN);
            if (usuario != null)
            {
                usuario = _context.Usuarios.FirstOrDefault(e => e.Password == password);
                if (usuario != null)
                {
                    loginPass = true;
                }
            }
            return loginPass;

        }
    }
}




