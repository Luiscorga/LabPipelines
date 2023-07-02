using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class EstadosOrdenRepository : IEstadosOrdenRepository
    {
        protected readonly Context _context;
        public EstadosOrdenRepository(Context context) => _context = context;

        public IEnumerable<EstadosOrden> GetEstadosOrdens()
        {
            return _context.EstadosOrdenes.ToList();
        }

        public EstadosOrden GetEstadosOrdenByid(int id)
        {
            return _context.EstadosOrdenes.Find(id);
        }

        public async Task<EstadosOrden> CreateEstadosOrdenAsync(EstadosOrden estadosOrden)
        {
            await _context.Set<EstadosOrden>().AddAsync(estadosOrden);
            await _context.SaveChangesAsync();
            return estadosOrden;
        }

        public async Task<bool> UpdateEstadosOrdenAsync(EstadosOrden estadosOrden)
        {
            _context.Entry(estadosOrden).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstadosOrdenAsync(EstadosOrden estadosOrden)
        {
            //var entity = await GetByIdAsync(id);
            if (estadosOrden is null)
            {
                return false;
            }
            _context.Set<EstadosOrden>().Remove(estadosOrden);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




