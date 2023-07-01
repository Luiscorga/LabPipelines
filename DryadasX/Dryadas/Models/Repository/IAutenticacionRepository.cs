using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IAutenticacionRepository
    {
        Task<Usuario> CreateAutenticacionAsync(Usuario autenticacion);
        Task<bool> DeleteAutenticacionAsync(Usuario autenticacion);
        Usuario GetAutenticacionByid(int id);
        IEnumerable<Usuario> GetAutenticacions();
        Task<bool> UpdateAutenticacionAsync(Usuario autenticacion);
        public bool Login(string usuarioN, string password);
    }
}
