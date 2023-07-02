using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenControllador : ControllerBase
    {
        private IOrdenRepository _ordenRepository;

        public OrdenControllador(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetOrdenesAsync))]
        public IEnumerable<Orden> GetOrdenesAsync()
        {
            return _ordenRepository.GetOrdenes();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetOrdenByid))]
        public ActionResult<Orden> GetOrdenByid(int id)
        {
            var ordenByID = _ordenRepository.GetOrdenById(id);
            if (ordenByID == null)
            {
                return NotFound();
            }
            return ordenByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateOrdenAsync))]
        public async Task<ActionResult<Orden>> CreateOrdenAsync(Orden orden)
        {
            await _ordenRepository.CreateOrdenAsync(orden);
            return CreatedAtAction(nameof(GetOrdenByid), new { id = orden.IdOrden }, orden);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateOrden))]
        public async Task<ActionResult> UpdateOrden(int id, Orden orden)
        {
            if (id != orden.IdOrden)
            {
                return BadRequest();
            }

            await _ordenRepository.UpdateOrdenAsync(orden);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteOrden))]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var orden = _ordenRepository.GetOrdenById(id);
            if (orden == null)
            {
                return NotFound();
            }

            await _ordenRepository.DeleteOrdenAsync(orden);

            return NoContent();
        }
    }
}