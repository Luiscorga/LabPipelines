using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class DetalleEventoRepository : IDetalleEventoRepository
    {
        protected readonly Context _context;
        public DetalleEventoRepository(Context context) => _context = context;

        public IEnumerable<DetalleEvento> GetDetalleEventos()
        {
            return _context.DetalleEventos.ToList();
        }

        public DetalleEvento GetDetalleEventoByid(int id)
        {
            return _context.DetalleEventos.Find(id);
        }

        public async Task<DetalleEvento> CreateDetalleEventoAsync(DetalleEvento detalleEvento)
        {
            await _context.Set<DetalleEvento>().AddAsync(detalleEvento);
            await _context.SaveChangesAsync();
            return detalleEvento;
        }

        public async Task<bool> UpdateDetalleEventoAsync(DetalleEvento detalleEvento)
        {
            _context.Entry(detalleEvento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDetalleEventoAsync(DetalleEvento detalleEvento)
        {
            //var entity = await GetByIdAsync(id);
            if (detalleEvento is null)
            {
                return false;
            }
            _context.Set<DetalleEvento>().Remove(detalleEvento);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




