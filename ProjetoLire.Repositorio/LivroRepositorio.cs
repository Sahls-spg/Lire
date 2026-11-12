using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Repositorio
{
    public class LivroRepositorio : BaseRepositorio, ILivroRepositorio
    {
        public LivroRepositorio(ProjetoLireContexto contexto) :base(contexto)
        {
             
        }

        public int Cadastrar(Livro livro)
        {
            _contexto.Livros.Add(livro);
            _contexto.SaveChanges();

            return livro.Id;
        }

        public void Atualizar(Livro livro)
        {
            _contexto.Livros.Update(livro);
            _contexto.SaveChanges();
        }

        public void Deletar(Livro livro)
        {
            _contexto.Livros.Remove(livro);
            _contexto.SaveChanges();
        }

        public Livro ObterPeloId(int livroId)
        {
            return _contexto.Livros.Where(livro => livro.Id == livroId).FirstOrDefault();
        }

        public Livro ObterPeloTituloEAutor(string titulo, string autor)
        {
            return _contexto.Livros.Where(livro => livro.Titulo == titulo && livro.Autor == autor).FirstOrDefault();
        }

        public List<Livro> Listar()
        {
            return _contexto.Livros.ToList();
        }
    }
}