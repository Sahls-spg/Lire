using Microsoft.EntityFrameworkCore;
using ProjetoLire.Aplicacao;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Repositorio;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjetoLireContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Lire")));

builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ILivroAplicacao, LivroAplicacao>();
builder.Services.AddScoped<ILeituraAplicacao, LeituraAplicacao>();
builder.Services.AddScoped<IPlanoLeituraAplicacao, PlanoLeituraAplicacao>();
builder.Services.AddScoped<ILivroBibliotecaAplicacao, LivroBibliotecaAplicacao>();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
builder.Services.AddScoped<ILeituraRepositorio, LeituraRepositorio>();
builder.Services.AddScoped<IPlanoLeituraRepositorio, PlanoLeituraRepositorio>();
builder.Services.AddScoped<ILivroBibliotecaRepositorio, LivroBibliotecaRepositorio>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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


