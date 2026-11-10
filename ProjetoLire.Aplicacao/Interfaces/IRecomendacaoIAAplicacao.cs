namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface IRecomendacaoIAAplicacao
    {
        public Task<string> GerarRecomendacoesAsync(int usuarioId);
    }
}