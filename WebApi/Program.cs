using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Data;
using WebApi.Data.Repositories;


// Crear un nuevo constructor de aplicación web
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor de dependencias
builder.Services.AddControllers();  // Agregar controladores para el manejo de solicitudes HTTP
builder.Services.AddSwaggerGen(c =>
{
    // Configurar Swagger para la generación de documentación de la API
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
});

// Configurar la conexión a MySQL y registrar el servicio como Singleton
var mySqlConfiguration = new MySqlConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySqlConfiguration);
// Registrar el repositorio de usuarios como un servicio
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Construir la aplicación web
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Habilitar Swagger y Swagger UI en el entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi V1");
    });
}
// Habilitar redirección HTTPS
app.UseHttpsRedirection();
// Habilitar autorización
app.UseAuthorization();
// Mapear los controladores
app.MapControllers();
// Ejecutar la aplicación
app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}