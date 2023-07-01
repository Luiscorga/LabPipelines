using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoProductoProductoControllador : ControllerBase
    {
        private IEstadoProductoProductoRepository _estadoProductoProductoRepository;

        public EstadoProductoProductoControllador(IEstadoProductoProductoRepository estadoProductoProductoRepository)
        {
            _estadoProductoProductoRepository = estadoProductoProductoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEstadoProductoProductosAsync))]
        public IEnumerable<EstadoProductoProducto> GetEstadoProductoProductosAsync()
        {
            return _estadoProductoProductoRepository.GetEstadoProductoProductos();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetEstadoProductoProductoByid))]
        public ActionResult<EstadoProductoProducto> GetEstadoProductoProductoByid(int id)
        {
            var estadoProductoProductoByID = _estadoProductoProductoRepository.GetEstadoProductoProductoByid(id);
            if (estadoProductoProductoByID == null)
            {
                return NotFound();
            }
            return estadoProductoProductoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateEstadoProductoProductoAsync))]
        public async Task<ActionResult<EstadoProductoProducto>> CreateEstadoProductoProductoAsync(EstadoProductoProducto estadoProductoProducto)
        {
            await _estadoProductoProductoRepository.CreateEstadoProductoProductoAsync(estadoProductoProducto);
            return CreatedAtAction(nameof(GetEstadoProductoProductoByid), new { id = estadoProductoProducto.IdEstadoProductoProducto }, estadoProductoProducto);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateEstadoProductoProducto))]
        public async Task<ActionResult> UpdateEstadoProductoProducto(int id, EstadoProductoProducto estadoProductoProducto)
        {
            if (id != estadoProductoProducto.IdEstadoProductoProducto)
            {
                return BadRequest();
            }

            await _estadoProductoProductoRepository.UpdateEstadoProductoProductoAsync(estadoProductoProducto);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEstadoProductoProducto))]
        public async Task<IActionResult> DeleteEstadoProductoProducto(int id)
        {
            var estadoProductoProducto = _estadoProductoProductoRepository.GetEstadoProductoProductoByid(id);
            if (estadoProductoProducto == null)
            {
                return NotFound();
            }

            await _estadoProductoProductoRepository.DeleteEstadoProductoProductoAsync(estadoProductoProducto);

            return NoContent();
        }
    }
}