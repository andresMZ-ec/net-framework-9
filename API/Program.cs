using DotNetEnv;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using API.Configuracion;
using Aplicacion.Interfaces;
using Dominio.Interfaces;
using Dominio.Servicios;
using Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Aplicacion.Servicios;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var configuracionBD = new ConeccionBD();
configuracionBD.ConectarMySql(builder);

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer").addjwt

//Scopeds
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IRolServicio, RolServicio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<IPermisoServicio, PermisoServicio>();
builder.Services.AddScoped<IPermisoRepositorio, PermisoRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSwagger().RequireAuthorization();

app.MapGet("/", () => "Hello World!")
    .WithName("Welcome Page")
    .WithOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
