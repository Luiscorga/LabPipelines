using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class EstadoProductoProductoRepository : IEstadoProductoProductoRepository
    {
        protected readonly Context _context;
        public EstadoProductoProductoRepository(Context context) => _context = context;

        public IEnumerable<EstadoProductoProducto> GetEstadoProductoProductos()
        {
            return _context.EstadoProductoProductos.ToList();
        }

        public EstadoProductoProducto GetEstadoProductoProductoByid(int id)
        {
            return _context.EstadoProductoProductos.Find(id);
        }

        public async Task<EstadoProductoProducto> CreateEstadoProductoProductoAsync(EstadoProductoProducto EstadoProductoProducto)
        {
            await _context.Set<EstadoProductoProducto>().AddAsync(EstadoProductoProducto);
            await _context.SaveChangesAsync();
            return EstadoProductoProducto;
        }

        public async Task<bool> UpdateEstadoProductoProductoAsync(EstadoProductoProducto EstadoProductoProducto)
        {
            _context.Entry(EstadoProductoProducto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstadoProductoProductoAsync(EstadoProductoProducto EstadoProductoProducto)
        {
            //var entity = await GetByIdAsync(id);
            if (EstadoProductoProducto is null)
            {
                return false;
            }
            _context.Set<EstadoProductoProducto>().Remove(EstadoProductoProducto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




