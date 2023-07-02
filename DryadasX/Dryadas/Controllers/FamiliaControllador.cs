using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaControllador : ControllerBase
    {
        private IFamiliaRepository _familiaRepository;

        public FamiliaControllador(IFamiliaRepository familiaRepository)
        {
            _familiaRepository = familiaRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetFamiliasAsync))]
        public IEnumerable<Familia> GetFamiliasAsync()
        {
            return _familiaRepository.GetFamilias();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetFamiliaByid))]
        public ActionResult<Familia> GetFamiliaByid(int id)
        {
            var familiaByID = _familiaRepository.GetFamiliaByid(id);
            if (familiaByID == null)
            {
                return NotFound();
            }
            return familiaByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateFamiliaAsync))]
        public async Task<ActionResult<Familia>> CreateFamiliaAsync(Familia familia)
        {
            await _familiaRepository.CreateFamiliaAsync(familia);
            return CreatedAtAction(nameof(GetFamiliaByid), new { id = familia.IdFamilia }, familia);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateFamilia))]
        public async Task<ActionResult> UpdateFamilia(int id, Familia familia)
        {
            if (id != familia.IdFamilia)
            {
                return BadRequest();
            }

            await _familiaRepository.UpdateFamiliaAsync(familia);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteFamilia))]
        public async Task<IActionResult> DeleteFamilia(int id)
        {
            var familia = _familiaRepository.GetFamiliaByid(id);
            if (familia == null)
            {
                return NotFound();
            }

            await _familiaRepository.DeleteFamiliaAsync(familia);

            return NoContent();
        }
    }
}