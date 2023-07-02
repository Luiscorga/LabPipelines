using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegiosControllador : ControllerBase
    {
        private IPrivilegiosRepository _privilegiosRepository;

        public PrivilegiosControllador(IPrivilegiosRepository privilegiosRepository)
        {
            _privilegiosRepository = privilegiosRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetPrivilegiossAsync))]
        public IEnumerable<Privilegios> GetPrivilegiossAsync()
        {
            return _privilegiosRepository.GetPrivilegioss();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetPrivilegiosByid))]
        public ActionResult<Privilegios> GetPrivilegiosByid(int id)
        {
            var privilegiosByID = _privilegiosRepository.GetPrivilegiosByid(id);
            if (privilegiosByID == null)
            {
                return NotFound();
            }
            return privilegiosByID;
        }

        [HttpPost]
        [ActionName(nameof(CreatePrivilegiosAsync))]
        public async Task<ActionResult<Privilegios>> CreatePrivilegiosAsync(Privilegios privilegios)
        {
            await _privilegiosRepository.CreatePrivilegiosAsync(privilegios);
            return CreatedAtAction(nameof(GetPrivilegiosByid), new { id = privilegios.IdPrivilegios }, privilegios);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdatePrivilegios))]
        public async Task<ActionResult> UpdatePrivilegios(int id, Privilegios privilegios)
        {
            if (id != privilegios.IdPrivilegios)
            {
                return BadRequest();
            }

            await _privilegiosRepository.UpdatePrivilegiosAsync(privilegios);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeletePrivilegios))]
        public async Task<IActionResult> DeletePrivilegios(int id)
        {
            var privilegios = _privilegiosRepository.GetPrivilegiosByid(id);
            if (privilegios == null)
            {
                return NotFound();
            }

            await _privilegiosRepository.DeletePrivilegiosAsync(privilegios);

            return NoContent();
        }
    }
}