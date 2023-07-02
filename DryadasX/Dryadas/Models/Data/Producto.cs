using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dryadas.Models.Data
{
    public class Producto
    {
        [Key]
        public int SKU { get; set; }
        public string Nombre { get; set; }
        public int AlquilerRetail { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public int AlquilerComercio { get; set;}
        public float Peso { get; set; }
        public float PesoReferencia { get;set; }

        [ForeignKey("Familia")]
        public int IdFamilia { get; set; }
        public Familia? Familia { get; set; }

        public ICollection<EstadoProductoProducto> EstadoProductoProductos { get; } = new List<EstadoProductoProducto>();

        public ICollection<DetalleOrden> DetallesOrdenes { get; } = new List<DetalleOrden>();
    }
}
