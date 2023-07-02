using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class EstadoProductoRepository : IEstadoProductoRepository
    {
        protected readonly Context _context;
        public EstadoProductoRepository(Context context) => _context = context;

        public IEnumerable<EstadoProducto> GetEstadoProductos()
        {
            return _context.EstadoProductos.ToList();
        }

        public EstadoProducto GetEstadoProductoByid(int id)
        {
            return _context.EstadoProductos.Find(id);
        }

        public async Task<EstadoProducto> CreateEstadoProductoAsync(EstadoProducto EstadoProducto)
        {
            await _context.Set<EstadoProducto>().AddAsync(EstadoProducto);
            await _context.SaveChangesAsync();
            return EstadoProducto;
        }

        public async Task<bool> UpdateEstadoProductoAsync(EstadoProducto EstadoProducto)
        {
            _context.Entry(EstadoProducto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstadoProductoAsync(EstadoProducto EstadoProducto)
        {
            //var entity = await GetByIdAsync(id);
            if (EstadoProducto is null)
            {
                return false;
            }
            _context.Set<EstadoProducto>().Remove(EstadoProducto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




