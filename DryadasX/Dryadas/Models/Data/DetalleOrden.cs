using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dryadas.Models.Data
{
    public class DetalleOrden
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Producto")]
        public int SKU { get; set; }
        public Producto? Producto { get; set; }

        [ForeignKey("Orden")]
        public int IdOrden { get; set; }
        public Orden? Orden { get; set; }

        public int CantidadTotal { get; set; }
        public int CantidadSinUsar { get; set; }
        public int CantidadUsados { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFinal { get; set; }

    }
}
