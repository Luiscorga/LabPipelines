using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
using Dryadas.Models.Repository;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44465").WithMethods("POST", "DELETE", "GET", "OPTIONS", "PUT").AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IFamiliaRepository, FamiliaRepository>();
builder.Services.AddTransient<IOrdenRepository, OrdenRepository>();
builder.Services.AddTransient<IDetalleOrdenRepository, DetalleOrdenRepository>();
builder.Services.AddTransient<IUsuarioClienteRepository, UsuarioClienteRepository>();
builder.Services.AddTransient<IEstadoProductoRepository, EstadoProductoRepository>();
builder.Services.AddTransient<IEstadoProductoProductoRepository, EstadoProductoProductoRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPrivilegiosRepository, PrivilegiosRepository>();
builder.Services.AddTransient<IEventoRepository, EventoRepository>();
builder.Services.AddTransient<IDetalleEventoRepository, DetalleEventoRepository>();
builder.Services.AddTransient<IEstadosOrdenRepository, EstadosOrdenRepository>();
builder.Services.AddTransient<IEstadoRepository, EstadoRepository>();
builder.Services.AddTransient<IAutenticacionRepository, AutenticacionRepository>();
//services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddDbContext<Context>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
