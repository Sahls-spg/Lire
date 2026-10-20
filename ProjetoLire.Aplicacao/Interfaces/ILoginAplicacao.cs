using ProjetoLire.Aplicacao.DTO;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILoginAplicacao
    {
        public Task<LoginResposta> LoginAsync(LoginRequisicao requisicao);
    }
}