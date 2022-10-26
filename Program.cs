using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Foi adicionado essa funcionalidade "middleware" para ignorar cenários de erro quando temos
// 1 entidade Produto dentro da entidade Categoria e uma entidade Categoria dentro de produto,
// ele começa a dar erro nesses cenários e a solução é ignorar esses ciclos duplicados
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<APICatalogoContext>(options =>
  options.UseMySql(
    mysqlConnection, 
    ServerVersion.AutoDetect(mysqlConnection)
  )
);

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
