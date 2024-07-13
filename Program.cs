using Entity.Interfaces;
using Entity.Models;
using Entity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProducto, ProductoServices>();
builder.Services.AddScoped<ICatalogo, CatalogoServices>();
builder.Services.AddScoped<ICliente, ClienteServices>();
builder.Services.AddScoped<IVenta, VentaServices>();
builder.Services.AddScoped<IVendedor, VendedorServices>();

builder.Services.AddDbContext<VentaspruebaContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();