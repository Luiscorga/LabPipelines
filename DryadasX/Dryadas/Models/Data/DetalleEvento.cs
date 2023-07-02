using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dryadas.Models.Data
{
    public class DetalleEvento
    {
        [Key]
        public int IdDetalleEvento { get; set; }

        [ForeignKey("Orden")]
        public int IdOrden { get; set; }
        public Orden? Orden { get; set; }

        [ForeignKey("Evento")]
        public int IdEvento { get; set; }
        public Evento? Evento { get; set; }

    }
}
