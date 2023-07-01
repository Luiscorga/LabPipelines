using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoControllador : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventoControllador(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEventosAsync))]
        public IEnumerable<Evento> GetEventosAsync()
        {
            return _eventoRepository.GetEventos();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetEventoByid))]
        public ActionResult<Evento> GetEventoByid(int id)
        {
            var eventoByID = _eventoRepository.GetEventoByid(id);
            if (eventoByID == null)
            {
                return NotFound();
            }
            return eventoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateEventoAsync))]
        public async Task<ActionResult<Evento>> CreateEventoAsync(Evento evento)
        {
            await _eventoRepository.CreateEventoAsync(evento);
            return CreatedAtAction(nameof(GetEventoByid), new { id = evento.IdEvento }, evento);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateEvento))]
        public async Task<ActionResult> UpdateEvento(int id, Evento evento)
        {
            if (id != evento.IdEvento)
            {
                return BadRequest();
            }

            await _eventoRepository.UpdateEventoAsync(evento);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEvento))]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = _eventoRepository.GetEventoByid(id);
            if (evento == null)
            {
                return NotFound();
            }

            await _eventoRepository.DeleteEventoAsync(evento);

            return NoContent();
        }
    }
}