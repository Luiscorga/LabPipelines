using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoProductoControllador : ControllerBase
    {
        private IEstadoProductoRepository _estadoProductoRepository;

        public EstadoProductoControllador(IEstadoProductoRepository estadoProductoRepository)
        {
            _estadoProductoRepository = estadoProductoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEstadoProductosAsync))]
        public IEnumerable<EstadoProducto> GetEstadoProductosAsync()
        {
            return _estadoProductoRepository.GetEstadoProductos();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetEstadoProductoByid))]
        public ActionResult<EstadoProducto> GetEstadoProductoByid(int id)
        {
            var estadoProductoByID = _estadoProductoRepository.GetEstadoProductoByid(id);
            if (estadoProductoByID == null)
            {
                return NotFound();
            }
            return estadoProductoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateEstadoProductoAsync))]
        public async Task<ActionResult<EstadoProducto>> CreateEstadoProductoAsync(EstadoProducto estadoProducto)
        {
            await _estadoProductoRepository.CreateEstadoProductoAsync(estadoProducto);
            return CreatedAtAction(nameof(GetEstadoProductoByid), new { id = estadoProducto.IdEstadoProducto }, estadoProducto);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateEstadoProducto))]
        public async Task<ActionResult> UpdateEstadoProducto(int id, EstadoProducto estadoProducto)
        {
            if (id != estadoProducto.IdEstadoProducto)
            {
                return BadRequest();
            }

            await _estadoProductoRepository.UpdateEstadoProductoAsync(estadoProducto);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEstadoProducto))]
        public async Task<IActionResult> DeleteEstadoProducto(int id)
        {
            var estadoProducto = _estadoProductoRepository.GetEstadoProductoByid(id);
            if (estadoProducto == null)
            {
                return NotFound();
            }

            await _estadoProductoRepository.DeleteEstadoProductoAsync(estadoProducto);

            return NoContent();
        }
    }
}