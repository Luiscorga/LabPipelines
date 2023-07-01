using System.ComponentModel.DataAnnotations;

namespace Dryadas.Models.Data
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Empresa { get; set; }
        public string Agregado { get; set; }
        public string Segmento { get; set; }
        public string Correo { get; set; }
        public int Prioridad { get; set; }
        public string NombreContrato { get; set; }
        public float PesoDeHuellaAmb { get; set; }
        public int Telefono { get; set; }
        public int Telefono2 { get; set; }
        public string PaginaWeb { get; set; }
        public ICollection<Orden> Orden { get; } = new List<Orden>();
        public ICollection<UsuarioCliente> UsuarioClientes { get; } = new List<UsuarioCliente>();

    }
}
