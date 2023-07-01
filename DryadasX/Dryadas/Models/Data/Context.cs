using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dryadas.Models.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleEvento> DetalleEventos { get; set; }
        public DbSet<DetalleOrden> DetalleOrdenes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<EstadoProducto> EstadoProductos { get; set; }
        public DbSet<EstadoProductoProducto> EstadoProductoProductos { get; set; }
        public DbSet<EstadosOrden> EstadosOrdenes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Privilegios> Privilegios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioCliente> UsuarioClientes { get; set; }

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter()
                : base(dateOnly =>
                        dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime))
            { }
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Remove any existing configuration related to Producto and Familia
        }

    }
}
