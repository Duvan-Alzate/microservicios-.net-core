using Clientes.Infrastructure.Data;
using Clientes.Application.Interfaces;
using Clientes.Infrastructure.Repositories;
using Clientes.Application.Services;
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
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<CrearClienteService>();
builder.Services.AddScoped<ObtenerClienteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();