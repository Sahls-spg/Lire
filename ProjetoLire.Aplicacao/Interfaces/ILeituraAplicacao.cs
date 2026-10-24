using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILeituraAplicacao
    {
        public Task<int> RegistrarAsync(LeituraCriar leitura);
        public Task AtualizarAsync(LeituraAtualizar leitura);
        public Task<List<LeituraResposta>> ListarAsync();
        public Task<List<LeituraResposta>> ListarPorUsuarioAsync(int usuarioId);
    }
}