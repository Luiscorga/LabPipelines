using System.ComponentModel.DataAnnotations;

namespace Dryadas.Models.Data
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public ICollection<DetalleEvento> DetalleEventos { get; } = new List<DetalleEvento>();
    }
}
