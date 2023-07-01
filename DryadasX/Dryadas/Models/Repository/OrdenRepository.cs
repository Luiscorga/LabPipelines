using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class OrdenRepository : IOrdenRepository
    {
        protected readonly Context _context;
        public OrdenRepository(Context context) => _context = context;

        public IEnumerable<Orden> GetOrdenes()
        {
            return _context.Ordenes.ToList();
        }

        public Orden GetOrdenById(int id)
        {
            return _context.Ordenes.Find(id);
        }

        public async Task<Orden> CreateOrdenAsync(Orden orden)
        {
            await _context.Set<Orden>().AddAsync(orden);
            await _context.SaveChangesAsync();
            return orden;
        }

        public async Task<bool> UpdateOrdenAsync(Orden orden)
        {
            _context.Entry(orden).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrdenAsync(Orden orden)
        {
            //var entity = await GetByIdAsync(id);
            if (orden is null)
            {
                return false;
            }
            _context.Set<Orden>().Remove(orden);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




