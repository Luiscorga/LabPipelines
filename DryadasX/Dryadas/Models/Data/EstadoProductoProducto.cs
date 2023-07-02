using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dryadas.Models.Data
{
    public class EstadoProductoProducto
    {
        [Key]
        public int IdEstadoProductoProducto { get; set; }

        [ForeignKey("EstadoProducto")]
        public int idEstadoProducto { get; set; }
        public EstadoProducto? EstadoProducto { get; set; }

        [ForeignKey("Producto")]
        public int SKU { get; set; }
        public Producto? Producto { get; set; }
    }
}
