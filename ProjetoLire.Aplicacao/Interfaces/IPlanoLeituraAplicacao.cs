using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface IPlanoLeituraAplicacao
    {
        public Task<int> CriarAsync(PlanoLeitura planoLeitura);
        public Task<PlanoLeitura> ObterPeloIdAsync(int planoLeituraId);
        public Task<PlanoLeitura> ListarAsync();
        public Task<PlanoLeitura> ListarPorUsuarioAsync(int usuarioId);
    }
}