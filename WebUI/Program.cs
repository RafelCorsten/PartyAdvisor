using MediatR;
using Serilog;
using System.Reflection;
using DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add SeriLog en WebUi    done

// SQL en DataBase
// EF Core en Domain
// MediatR en WebUI y en Application
// AutoMapper en WebUI y Application
// Relacion de proyectos
// FluentValidation en Application
// StyleCop en todas las capas
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.WriteTo.Console();
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDatabaseInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
