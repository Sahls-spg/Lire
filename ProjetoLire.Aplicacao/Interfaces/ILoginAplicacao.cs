using ProjetoLire.Aplicacao.DTO;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILoginAplicacao
    {
        Task<LoginResposta> LoginAsync(LoginRequisicao requisicao);
    }
}