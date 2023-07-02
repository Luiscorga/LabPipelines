using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosOrdenControllador : ControllerBase
    {
        private IEstadosOrdenRepository _estadosOrdenRepository;

        public EstadosOrdenControllador(IEstadosOrdenRepository estadosOrdenRepository)
        {
            _estadosOrdenRepository = estadosOrdenRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEstadosOrdensAsync))]
        public IEnumerable<EstadosOrden> GetEstadosOrdensAsync()
        {
            return _estadosOrdenRepository.GetEstadosOrdens();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetEstadosOrdenByid))]
        public ActionResult<EstadosOrden> GetEstadosOrdenByid(int id)
        {
            var estadosOrdenByID = _estadosOrdenRepository.GetEstadosOrdenByid(id);
            if (estadosOrdenByID == null)
            {
                return NotFound();
            }
            return estadosOrdenByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateEstadosOrdenAsync))]
        public async Task<ActionResult<EstadosOrden>> CreateEstadosOrdenAsync(EstadosOrden estadosOrden)
        {
            await _estadosOrdenRepository.CreateEstadosOrdenAsync(estadosOrden);
            return CreatedAtAction(nameof(GetEstadosOrdenByid), new { id = estadosOrden.IdEstadosOrden }, estadosOrden);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateEstadosOrden))]
        public async Task<ActionResult> UpdateEstadosOrden(int id, EstadosOrden estadosOrden)
        {
            if (id != estadosOrden.IdEstadosOrden)
            {
                return BadRequest();
            }

            await _estadosOrdenRepository.UpdateEstadosOrdenAsync(estadosOrden);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEstadosOrden))]
        public async Task<IActionResult> DeleteEstadosOrden(int id)
        {
            var estadosOrden = _estadosOrdenRepository.GetEstadosOrdenByid(id);
            if (estadosOrden == null)
            {
                return NotFound();
            }

            await _estadosOrdenRepository.DeleteEstadosOrdenAsync(estadosOrden);

            return NoContent();
        }
    }
}