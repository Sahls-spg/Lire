using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface IRecomendacaoIAAplicacao
    {
        public Task<List<Livro>> GerarRecomendacoesAsync(int usuarioId);
    }
}