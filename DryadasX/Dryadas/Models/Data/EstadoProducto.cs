using System.ComponentModel.DataAnnotations;

namespace Dryadas.Models.Data
{
    public class EstadoProducto
    {
        [Key]
        public int IdEstadoProducto { get; set; }
        public string NombreEstado { get; set; }
        public ICollection<EstadoProductoProducto> EstadoProductoProductos { get; } = new List<EstadoProductoProducto>();
    }
}
