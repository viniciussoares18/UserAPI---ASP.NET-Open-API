using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Repository;
using UserApi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adiciona o Entity Framework como Servi�o, referencia qual contexto deve ser usado,
//declara qual op��o de Banco de Dados deve ser usada
// e traz as configura��es de conex�o declaradas no AppSettnigs
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<DatabaseContext>(options => options
    .UseSqlServer(builder.Configuration
    .GetConnectionString("SqlConnection")));

// Todas vez que um m�todo da interface for acionado, ser� inst�nciado um objeto da classe UsuarioRepository que implementa essa interface.
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
