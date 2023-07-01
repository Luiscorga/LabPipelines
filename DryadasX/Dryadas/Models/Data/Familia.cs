using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Dryadas.Models.Data
{
    public class Familia
    {
        [Key]
        public int IdFamilia { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; } = new List<Producto>();
    }
}
