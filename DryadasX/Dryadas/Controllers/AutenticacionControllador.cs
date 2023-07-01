using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionControllador : ControllerBase
    {
        private IAutenticacionRepository _autenticacionRepository;

        public AutenticacionControllador(IAutenticacionRepository usuarioRepository)
        {
            _autenticacionRepository = usuarioRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetAutenticacionsAsync))]
        public IEnumerable<Usuario> GetAutenticacionsAsync()
        {
            return _autenticacionRepository.GetAutenticacions();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetAutenticacionByid))]
        public ActionResult<Usuario> GetAutenticacionByid(int id)
        {
            var usuarioByID = _autenticacionRepository.GetAutenticacionByid(id);
            if (usuarioByID == null)
            {
                return NotFound();
            }
            return usuarioByID;
        }

        [HttpPost]
        [ActionName(nameof(Login))]
        public bool Login(string usuarioN, string password)
        {
            bool result = _autenticacionRepository.Login(usuarioN, password);
            if (!result)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAutenticacion))]
        public async Task<ActionResult> UpdateAutenticacion(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            await _autenticacionRepository.UpdateAutenticacionAsync(usuario);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteAutenticacion))]
        public async Task<IActionResult> DeleteAutenticacion(int id)
        {
            var usuario = _autenticacionRepository.GetAutenticacionByid(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _autenticacionRepository.DeleteAutenticacionAsync(usuario);

            return NoContent();
        }
        
      
        
    }
}