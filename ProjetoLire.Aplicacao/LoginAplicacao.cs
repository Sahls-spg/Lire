using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Aplicacao.JWT;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao
{
    public class LoginAplicacao : ILoginAplicacao
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;
        private readonly TokenService _tokenservice;

        public LoginAplicacao(IUsuarioAplicacao usuarioAplicacao, TokenService tokenService)
        {
            _usuarioAplicacao = usuarioAplicacao;
            _tokenservice = tokenService;
        }

        public async Task<LoginResposta> LoginAsync(LoginRequisicao loginRequisicao)
        {
            if(string.IsNullOrWhiteSpace(loginRequisicao.Email) || string.IsNullOrWhiteSpace(loginRequisicao.Senha))
            {
                throw new Exception("É necessário informar o e-mail e a senha");
            }

            var usuario = await _usuarioAplicacao.ObterPeloEmail(loginRequisicao.Email);

            if(usuario == null)
            {
                throw new Exception("Usuário não encontrado, verifique se o e-mail informado está correto");
            }

            if(usuario.Senha != loginRequisicao.Senha)
            {
                throw new Exception("Senha inválida, verifique se a senha informada está correta");
            }

            var tokenGerado = _tokenservice.GerarToken(usuario);

            var token = new LoginResposta()
            {
                Token = tokenGerado
            };

            return token;
        }
    }
}