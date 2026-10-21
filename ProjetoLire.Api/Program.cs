using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoLire.Aplicacao;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Aplicacao.JWT;
using ProjetoLire.Repositorio;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

builder.Services.AddSingleton(jwtSettings);

builder.Services.AddScoped<TokenService>();

builder.Services.AddDbContext<ProjetoLireContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Lire")));

builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ILivroAplicacao, LivroAplicacao>();
builder.Services.AddScoped<ILeituraAplicacao, LeituraAplicacao>();
builder.Services.AddScoped<IPlanoLeituraAplicacao, PlanoLeituraAplicacao>();
builder.Services.AddScoped<ILivroBibliotecaAplicacao, LivroBibliotecaAplicacao>();
builder.Services.AddScoped<ILoginAplicacao, LoginAplicacao>();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
builder.Services.AddScoped<ILeituraRepositorio, LeituraRepositorio>();
builder.Services.AddScoped<IPlanoLeituraRepositorio, PlanoLeituraRepositorio>();
builder.Services.AddScoped<ILivroBibliotecaRepositorio, LivroBibliotecaRepositorio>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtSettings.Emissor,
            ValidAudience = jwtSettings.Audiencia,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Chave)
            ),
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


