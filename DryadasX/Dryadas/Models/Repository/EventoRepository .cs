using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class EventoRepository : IEventoRepository
    {
        protected readonly Context _context;
        public EventoRepository(Context context) => _context = context;

        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos.ToList();
        }

        public Evento GetEventoByid(int id)
        {
            return _context.Eventos.Find(id);
        }

        public async Task<Evento> CreateEventoAsync(Evento evento)
        {
            await _context.Set<Evento>().AddAsync(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> UpdateEventoAsync(Evento evento)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEventoAsync(Evento evento)
        {
            //var entity = await GetByIdAsync(id);
            if (evento is null)
            {
                return false;
            }
            _context.Set<Evento>().Remove(evento);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




