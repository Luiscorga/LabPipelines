using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteControllador : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClienteControllador(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetClientesAsync))]
        public IEnumerable<Cliente> GetClientesAsync()
        {
            return _clienteRepository.GetClientes();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetClienteByid))]
        public ActionResult<Cliente> GetClienteByid(int id)
        {
            var clienteByID = _clienteRepository.GetClienteByid(id);
            if (clienteByID == null)
            {
                return NotFound();
            }
            return clienteByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateClienteAsync))]
        public async Task<ActionResult<Cliente>> CreateClienteAsync(Cliente cliente)
        {
            await _clienteRepository.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteByid), new { id = cliente.IdCliente }, cliente);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateCliente))]
        public async Task<ActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            await _clienteRepository.UpdateClienteAsync(cliente);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCliente))]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = _clienteRepository.GetClienteByid(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteRepository.DeleteClienteAsync(cliente);

            return NoContent();
        }
    }
}