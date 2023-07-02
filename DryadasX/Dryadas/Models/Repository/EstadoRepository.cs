using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class EstadoRepository : IEstadoRepository
    {
        protected readonly Context _context;
        public EstadoRepository(Context context) => _context = context;

        public IEnumerable<Estado> GetEstados()
        {
            return _context.Estados.ToList();
        }

        public Estado GetEstadoByid(int id)
        {
            return _context.Estados.Find(id);
        }

        public async Task<Estado> CreateEstadoAsync(Estado estado)
        {
            await _context.Set<Estado>().AddAsync(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task<bool> UpdateEstadoAsync(Estado estado)
        {
            _context.Entry(estado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstadoAsync(Estado estado)
        {
            //var entity = await GetByIdAsync(id);
            if (estado is null)
            {
                return false;
            }
            _context.Set<Estado>().Remove(estado);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




