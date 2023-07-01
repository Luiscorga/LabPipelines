using Dryadas.Models.Data;

namespace Dryadas.Models.Repository
{
    public interface IProductoRepository
    {
        Task<Producto> CreateProductAsync(Producto producto);
        Task<bool> DeleteProductAsync(Producto producto);
        Producto GetProductById(int id);
        IEnumerable<Producto> GetProducts();
        Task<bool> UpdateProductAsync(Producto product);
    }
}
