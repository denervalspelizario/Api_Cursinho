using Cursinho.Infraestrutura;
using Cursinho.Infraestrutura.Autor;
using Cursinho.Model.Autor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// método que adiciona token ao swagger 
builder.Services.AddInfrastructureSwagger();

builder.Services.AddTransient<IAdministradorRepository, AdministradorRepository>();

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
