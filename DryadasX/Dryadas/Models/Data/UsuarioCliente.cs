using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dryadas.Models.Data
{
    public class UsuarioCliente
    {
        [Key]
        public int IdUsuarioCliente { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
