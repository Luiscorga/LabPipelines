using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleEventoControllador : ControllerBase
    {
        private IDetalleEventoRepository _detalleEventoRepository;

        public DetalleEventoControllador(IDetalleEventoRepository detalleEventoRepository)
        {
            _detalleEventoRepository = detalleEventoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetDetalleEventosAsync))]
        public IEnumerable<DetalleEvento> GetDetalleEventosAsync()
        {
            return _detalleEventoRepository.GetDetalleEventos();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetDetalleEventoByid))]
        public ActionResult<DetalleEvento> GetDetalleEventoByid(int id)
        {
            var detalleEventoByID = _detalleEventoRepository.GetDetalleEventoByid(id);
            if (detalleEventoByID == null)
            {
                return NotFound();
            }
            return detalleEventoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateDetalleEventoAsync))]
        public async Task<ActionResult<DetalleEvento>> CreateDetalleEventoAsync(DetalleEvento detalleEvento)
        {
            await _detalleEventoRepository.CreateDetalleEventoAsync(detalleEvento);
            return CreatedAtAction(nameof(GetDetalleEventoByid), new { id = detalleEvento.IdDetalleEvento }, detalleEvento);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateDetalleEvento))]
        public async Task<ActionResult> UpdateDetalleEvento(int id, DetalleEvento detalleEvento)
        {
            if (id != detalleEvento.IdDetalleEvento)
            {
                return BadRequest();
            }

            await _detalleEventoRepository.UpdateDetalleEventoAsync(detalleEvento);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteDetalleEvento))]
        public async Task<IActionResult> DeleteDetalleEvento(int id)
        {
            var detalleEvento = _detalleEventoRepository.GetDetalleEventoByid(id);
            if (detalleEvento == null)
            {
                return NotFound();
            }

            await _detalleEventoRepository.DeleteDetalleEventoAsync(detalleEvento);

            return NoContent();
        }
    }
}