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
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection(JwtSettings.Secao).Get<JwtSettings>()
    ?? throw new InvalidOperationException("A configuração JwtSettings não foi encontrada.");

builder.Services.AddSingleton(jwtSettings);
builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Emissor,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audiencia,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Chave)),
        };
    });

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

builder.Services.AddControllers()
    .AddJsonOptions(opcoes =>
        opcoes.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        )
    );

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


