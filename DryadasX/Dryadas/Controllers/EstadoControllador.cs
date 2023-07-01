using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoControllador : ControllerBase
    {
        private IEstadoRepository _estadoRepository;

        public EstadoControllador(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEstadosAsync))]
        public IEnumerable<Estado> GetEstadosAsync()
        {
            return _estadoRepository.GetEstados();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetEstadoByid))]
        public ActionResult<Estado> GetEstadoByid(int id)
        {
            var estadoByID = _estadoRepository.GetEstadoByid(id);
            if (estadoByID == null)
            {
                return NotFound();
            }
            return estadoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateEstadoAsync))]
        public async Task<ActionResult<Estado>> CreateEstadoAsync(Estado estado)
        {
            await _estadoRepository.CreateEstadoAsync(estado);
            return CreatedAtAction(nameof(GetEstadoByid), new { id = estado.IdEstado }, estado);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateEstado))]
        public async Task<ActionResult> UpdateEstado(int id, Estado estado)
        {
            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            await _estadoRepository.UpdateEstadoAsync(estado);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEstado))]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var estado = _estadoRepository.GetEstadoByid(id);
            if (estado == null)
            {
                return NotFound();
            }

            await _estadoRepository.DeleteEstadoAsync(estado);

            return NoContent();
        }
    }
}