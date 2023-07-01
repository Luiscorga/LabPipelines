using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class ProductoRepository : IProductoRepository
    {
        protected readonly Context _context;
        public ProductoRepository(Context context) => _context = context;

        public IEnumerable<Producto> GetProducts()
        {
            return _context.Productos.ToList();
        }

        public Producto GetProductById(int id)
        {
            return _context.Productos.Find(id);
        }

        public async Task<Producto> CreateProductAsync(Producto product)
        {
            await _context.Set<Producto>().AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Producto product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(Producto product)
        {
            //var entity = await GetByIdAsync(id);
            if (product is null)
            {
                return false;
            }
            _context.Set<Producto>().Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
