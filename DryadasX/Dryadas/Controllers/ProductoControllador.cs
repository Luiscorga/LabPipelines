using Dryadas.Models.Data;
using Dryadas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dryadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoControllador : ControllerBase
    {
        private IProductoRepository _productRepository;

        public ProductoControllador(IProductoRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetProductsAsync))]
        public IEnumerable<Producto> GetProductsAsync()
        {
            return _productRepository.GetProducts();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetProductById))]
        public ActionResult<Producto> GetProductById(int id)
        {
            var productByID = _productRepository.GetProductById(id);
            if (productByID == null)
            {
                return NotFound();
            }
            return productByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateProductAsync))]
        public async Task<ActionResult<Producto>> CreateProductAsync([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            await _productRepository.CreateProductAsync(producto);
            return CreatedAtAction(nameof(GetProductById), new { id = producto.SKU }, producto);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct(int id, Producto producto)
        {
            if (id != producto.SKU)
            {
                return BadRequest();
            }

            await _productRepository.UpdateProductAsync(producto);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteProductAsync(product);

            return NoContent();
        }
    }
}