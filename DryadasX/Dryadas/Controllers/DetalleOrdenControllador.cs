using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenControllador : ControllerBase
    {
        private IDetalleOrdenRepository _detalleOrdenRepository;

        public DetalleOrdenControllador(IDetalleOrdenRepository detalleOrdenRepository)
        {
            _detalleOrdenRepository = detalleOrdenRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetDetalleOrdenesAsync))]
        public IEnumerable<DetalleOrden> GetDetalleOrdenesAsync()
        {
            return _detalleOrdenRepository.GetDetalleOrdenes();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetDetalleOrdenByid))]
        public ActionResult<DetalleOrden> GetDetalleOrdenByid(int id)
        {
            var detalleOrdenByID = _detalleOrdenRepository.GetDetalleOrdenById(id);
            if (detalleOrdenByID == null)
            {
                return NotFound();
            }
            return detalleOrdenByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateDetalleOrdenAsync))]
        public async Task<ActionResult<Orden>> CreateDetalleOrdenAsync(DetalleOrden detalleOrden)
        {
            await _detalleOrdenRepository.CreateDetalleOrdenAsync(detalleOrden);
            return CreatedAtAction(nameof(GetDetalleOrdenByid), new { id = detalleOrden.id }, detalleOrden);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateDetalleOrden))]
        public async Task<ActionResult> UpdateDetalleOrden(int id, DetalleOrden detalleorden)
        {
            if (id != detalleorden.id)
            {
                return BadRequest();
            }

            await _detalleOrdenRepository.UpdateDetalleOrdenAsync(detalleorden);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteDetalleOrden))]
        public async Task<IActionResult> DeleteDetalleOrden(int id)
        {
            var orden = _detalleOrdenRepository.GetDetalleOrdenById(id);
            if (orden == null)
            {
                return NotFound();
            }

            await _detalleOrdenRepository.DeleteDetalleOrdenAsync(orden);

            return NoContent();
        }
    }
}