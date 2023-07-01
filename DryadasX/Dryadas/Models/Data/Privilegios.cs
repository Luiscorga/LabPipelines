using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dryadas.Models.Data
{
    public class Privilegios
    {
        [Key]
        public int IdPrivilegios { get; set; }
    }
}
