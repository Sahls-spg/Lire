using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ProjetoLire.Aplicacao.JWT
{
    public class TokenService
    {
        private readonly JwtSettings _settings;

        public TokenService(JwtSettings settings)
        {
            _settings = settings;
        }

        public string GerarToken(int usuarioId, string email)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),

                new Claim(ClaimTypes.Email, email)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Chave));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken 
            (
                issuer: _settings.Emissor,

                audience: _settings.Audiencia,

                claims: claims,

                expires: DateTime.UtcNow.AddMinutes(_settings.ExpiracaoToken), signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}