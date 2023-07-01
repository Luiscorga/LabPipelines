using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dryadas.Models.Data
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string PNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string Password { get; set; }

        //public virtual ICollection<Orden> Orden { get; set; }
        public ICollection<Orden> Ordenes { get; } = new List<Orden>();
        public ICollection<UsuarioCliente> UsuarioClientes { get; } = new List<UsuarioCliente>();

    }
}
