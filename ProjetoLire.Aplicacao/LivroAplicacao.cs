using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class LivroAplicacao : ILivroAplicacao
    {
        readonly ILivroRepositorio _livroRepositorio;

        public LivroAplicacao(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<int> CadastrarAsync(Livro livro)
        {
            
            if(livro == null)
            {
                throw new Exception("O livro não pode ser vazio.");
            }

            ValidarInformacoesLivro(livro);

            _livroRepositorio.Cadastrar(livro);

            return livro.Id;
        }

        public async Task AtualizarAsync(Livro livro)
        {
            var livroDominio =_livroRepositorio.ObterPeloId(livro.Id);

            if(livroDominio == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            ValidarInformacoesLivro(livro);

            livroDominio.Titulo = livro.Titulo;
            livroDominio.Autor = livro.Autor;
            livroDominio.Sinopse = livro.Sinopse;
            livroDominio.QuantidadeDePaginas = livro.QuantidadeDePaginas;
            livroDominio.GeneroLiterario = livro.GeneroLiterario;

            _livroRepositorio.Atualizar(livro);
        }

        public async Task DeletarAsync(int livroId)
        {
            var livroDeletar = _livroRepositorio.ObterPeloId(livroId);

            if(livroDeletar == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            _livroRepositorio.Deletar(livroDeletar);
        }

        public async Task<Livro> ObterPeloIdAsync(int livroId)
        {
            var livroDominio = _livroRepositorio.ObterPeloId(livroId);

            if(livroDominio == null)
            {
                throw new Exception("Livro não encontrado."); 
            }
            
            return livroDominio;
        }

        public async Task<List<Livro>> ListarAsync()
        {
            var listaLivros = _livroRepositorio.Listar();

            if(listaLivros == null)
            {
                throw new Exception("Não há livros para listar."); 
            }

            return listaLivros;
        }

        private static void ValidarInformacoesLivro(Livro livro)
        {
            if(string.IsNullOrEmpty(livro.Titulo))
            {
                throw new Exception("O título do livro não pode ser vazio.");
            }

            if(string.IsNullOrEmpty(livro.Autor))
            {
                throw new Exception("O nome do(a) autor(a) não pode ser vazio.");
            }

            if(livro.QuantidadeDePaginas <= 0)
            {
                throw new Exception("A quantidade de páginas do livro não pode ser negativa.");
            }
        }
    }
}