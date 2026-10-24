using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface IPlanoLeituraAplicacao
    {
        public Task<int> CriarAsync(PlanoLeituraCriar planoLeitura);
        public Task<PlanoLeituraResposta> ObterPeloIdAsync(int planoLeituraId);
        public Task<List<PlanoLeituraResposta>> ListarAsync();
        public Task<List<PlanoLeituraResposta>> ListarPorUsuarioAsync(int usuarioId);
    }
}