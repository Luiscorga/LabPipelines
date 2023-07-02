using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dryadas.Models.Data
{
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }
        public string Alquiler { get; set; }
        public int Estado { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        public ICollection<DetalleOrden> DetallesOrdenes { get; } = new List<DetalleOrden>();

        public ICollection<EstadosOrden> EstadosOrdenes { get; } = new List<EstadosOrden>();

        public ICollection<DetalleEvento> DetalleEventos { get; } = new List<DetalleEvento>();
    }
}
