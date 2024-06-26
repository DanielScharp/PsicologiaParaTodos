using Psicologia.App;
using Psicologia.Database.Repositorios;

var builder = WebApplication.CreateBuilder(args);
//--------------------------------------------------------
// Add services to the container.
IConfiguration configuration = builder.Configuration;

string connectionString = configuration.GetConnectionString("MySqlConnection");

// Criando instâncias de UsuarioRepositorio      
var usuarioRepositorio = new UsuarioRepositorio(connectionString);

// Adicionando as instâncias ao contêiner de serviços
builder.Services.AddSingleton(usuarioRepositorio);

builder.Services.AddScoped<UsuarioApplication>();
//--------------------------------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
