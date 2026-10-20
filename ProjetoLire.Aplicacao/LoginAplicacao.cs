using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Aplicacao.JWT;

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
                throw new Exception("É necessário informar o e-mail e a senha.");
            }

     
        }
    }
}