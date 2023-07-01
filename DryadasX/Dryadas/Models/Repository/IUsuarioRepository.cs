using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<bool> DeleteUsuarioAsync(Usuario usuario);
        Usuario GetUsuarioByid(int id);
        IEnumerable<Usuario> GetUsuarios();
        Task<bool> UpdateUsuarioAsync(Usuario usuario);
    }
}
