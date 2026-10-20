using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILivroAplicacao
    {
        public Task<int> CadastrarAsync(Livro livro);
        public Task AtualizarAsync(Livro livro);
        public Task DeletarAsync(int livroId);
        public Task<Livro> ObterPeloIdAsync(int livroId);
        public Task<List<Livro>> ListarAsync();
    }
}