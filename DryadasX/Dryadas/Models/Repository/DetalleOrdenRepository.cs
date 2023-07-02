using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class DetalleOrdenRepository : IDetalleOrdenRepository
    {
        protected readonly Context _context;
        public DetalleOrdenRepository(Context context) => _context = context;

        public IEnumerable<DetalleOrden> GetDetalleOrdenes()
        {
            return _context.DetalleOrdenes.ToList();
        }

        public DetalleOrden GetDetalleOrdenById(int id)
        {
            return _context.DetalleOrdenes.Find(id);
        }

        public async Task<DetalleOrden> CreateDetalleOrdenAsync(DetalleOrden detalleOrden)
        {
            await _context.Set<DetalleOrden>().AddAsync(detalleOrden);
            await _context.SaveChangesAsync();
            return detalleOrden;
        }

        public async Task<bool> UpdateDetalleOrdenAsync(DetalleOrden detalleOrden)
        {
            _context.Entry(detalleOrden).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDetalleOrdenAsync(DetalleOrden detalleOrden)
        {
            //var entity = await GetByIdAsync(id);
            if (detalleOrden is null)
            {
                return false;
            }
            _context.Set<DetalleOrden>().Remove(detalleOrden);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




