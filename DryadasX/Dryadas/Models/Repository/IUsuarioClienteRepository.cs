using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IUsuarioClienteRepository
    {
        Task<UsuarioCliente> CreateUsuarioClienteAsync(UsuarioCliente usuarioUsuarioCliente);
        Task<bool> DeleteUsuarioClienteAsync(UsuarioCliente usuarioUsuarioCliente);
        UsuarioCliente GetUsuarioClienteByid(int id);
        IEnumerable<UsuarioCliente> GetUsuarioClientes();
        Task<bool> UpdateUsuarioClienteAsync(UsuarioCliente usuarioUsuarioCliente);
    }
}
