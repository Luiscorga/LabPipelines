using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Dryadas.Models.Data
{
    public class EstadosOrden
    {
        [Key]
        public int IdEstadosOrden { get; set; }

        [ForeignKey("Orden")]
        public int IdOrden{ get; set; }
        public Orden? Orden { get; set; }

        [ForeignKey("Estado")]
        public int IdEstado { get; set; }
        public Estado? Estado { get; set; }
    }
}
