using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioControllador : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioControllador(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetUsuariosAsync))]
        public IEnumerable<Usuario> GetUsuariosAsync()
        {
            return _usuarioRepository.GetUsuarios();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetUsuarioByid))]
        public ActionResult<Usuario> GetUsuarioByid(int id)
        {
            var usuarioByID = _usuarioRepository.GetUsuarioByid(id);
            if (usuarioByID == null)
            {
                return NotFound();
            }
            return usuarioByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateUsuarioAsync))]
        public async Task<ActionResult<Usuario>> CreateUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuarioByid), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateUsuario))]
        public async Task<ActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            await _usuarioRepository.UpdateUsuarioAsync(usuario);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteUsuario))]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = _usuarioRepository.GetUsuarioByid(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioRepository.DeleteUsuarioAsync(usuario);

            return NoContent();
        }
    }
}