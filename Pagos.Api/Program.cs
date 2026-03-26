using Pagos.Infrastructure.Data;
using Pagos.Application.Interfaces;
using Pagos.Infrastructure.Repositories;
using Pagos.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DB MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Inyección de dependencias
builder.Services.AddScoped<IPagoRepository, PagoRepository>();
builder.Services.AddScoped<CrearPagoService>();
builder.Services.AddScoped<ObtenerPagosService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();