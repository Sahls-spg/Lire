using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILivroAplicacao
    {
        public Task<int> CadastrarAsync(LivroCriar livro);
        public Task AtualizarAsync(LivroAtualizar livro);
        public Task DeletarAsync(int livroId);
        public Task<LivroResposta> ObterPeloIdAsync(int livroId);
        public Task<List<LivroResposta>> ListarAsync();
    }
}