using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface ILivroRepositorio
    {
        public Task Cadastrar(Livro livro);
        public Task Atualizar(Livro livro);
        public Task Deletar(Livro livro);
        public Task<Livro> ObterPeloId(int livroId);
        public Task<List<Livro>> Listar();
    }
}