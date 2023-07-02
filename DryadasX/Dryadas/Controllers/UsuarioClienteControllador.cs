using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioClienteControllador : ControllerBase
    {
        private IUsuarioClienteRepository _usuarioClienteRepository;

        public UsuarioClienteControllador(IUsuarioClienteRepository usuarioClienteRepository)
        {
            _usuarioClienteRepository = usuarioClienteRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetUsuarioClientesAsync))]
        public IEnumerable<UsuarioCliente> GetUsuarioClientesAsync()
        {
            return _usuarioClienteRepository.GetUsuarioClientes();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetUsuarioClienteByid))]
        public ActionResult<UsuarioCliente> GetUsuarioClienteByid(int id)
        {
            var usuarioClienteByID = _usuarioClienteRepository.GetUsuarioClienteByid(id);
            if (usuarioClienteByID == null)
            {
                return NotFound();
            }
            return usuarioClienteByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateUsuarioClienteAsync))]
        public async Task<ActionResult<UsuarioCliente>> CreateUsuarioClienteAsync(UsuarioCliente usuarioCliente)
        {
            await _usuarioClienteRepository.CreateUsuarioClienteAsync(usuarioCliente);
            return CreatedAtAction(nameof(GetUsuarioClienteByid), new { id = usuarioCliente.IdUsuarioCliente }, usuarioCliente);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateUsuarioCliente))]
        public async Task<ActionResult> UpdateUsuarioCliente(int id, UsuarioCliente usuarioCliente)
        {
            if (id != usuarioCliente.IdUsuarioCliente)
            {
                return BadRequest();
            }

            await _usuarioClienteRepository.UpdateUsuarioClienteAsync(usuarioCliente);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteUsuarioCliente))]
        public async Task<IActionResult> DeleteUsuarioCliente(int id)
        {
            var usuarioCliente = _usuarioClienteRepository.GetUsuarioClienteByid(id);
            if (usuarioCliente == null)
            {
                return NotFound();
            }

            await _usuarioClienteRepository.DeleteUsuarioClienteAsync(usuarioCliente);

            return NoContent();
        }
    }
}