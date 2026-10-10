using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface ILivroRepositorio
    {
        public int Cadastrar(Livro livro);
        public void Atualizar(Livro livro);
        public void Deletar(Livro livro);
        public Livro ObterPeloId(int livroId);
        public List<Livro> Listar();
    }
}