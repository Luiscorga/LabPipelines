using System.ComponentModel.DataAnnotations;

namespace Dryadas.Models.Data
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public ICollection<EstadosOrden> EstadosOrdenes { get; } = new List<EstadosOrden>();

    }
}
