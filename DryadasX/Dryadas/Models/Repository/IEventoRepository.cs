using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IEventoRepository
    {
        Task<Evento> CreateEventoAsync(Evento evento);
        Task<bool> DeleteEventoAsync(Evento evento);
        Evento GetEventoByid(int id);
        IEnumerable<Evento> GetEventos();
        Task<bool> UpdateEventoAsync(Evento evento);
    }
}
