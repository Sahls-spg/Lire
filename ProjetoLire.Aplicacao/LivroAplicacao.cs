using ProjetoLire.Aplicacao.DTO;
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

        public async Task<int> CadastrarAsync(LivroCriar livro)
        {

            if (livro == null)
            {
                throw new Exception("O livro não pode ser vazio.");
            }

            ValidarInformacoesLivro(livro.Titulo, livro.Autor, livro.QuantidadeDePaginas);

            var livroDominio = new Livro
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                GeneroLiterario = livro.GeneroLiterario,
                QuantidadeDePaginas = livro.QuantidadeDePaginas,
                Sinopse = livro.Sinopse
            };

            var livroId = _livroRepositorio.Cadastrar(livroDominio);

            return livroId;
        }

        public async Task AtualizarAsync(LivroAtualizar livro)
        {
            var livroDominio = _livroRepositorio.ObterPeloId(livro.Id);

            if (livroDominio == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            ValidarInformacoesLivro(livro.Titulo, livro.Autor, livro.QuantidadeDePaginas);

            livroDominio.Titulo = livro.Titulo;
            livroDominio.Autor = livro.Autor;
            livroDominio.Sinopse = livro.Sinopse;
            livroDominio.QuantidadeDePaginas = livro.QuantidadeDePaginas;
            livroDominio.GeneroLiterario = livro.GeneroLiterario;

            _livroRepositorio.Atualizar(livroDominio);
        }

        public async Task DeletarAsync(int livroId)
        {
            var livroDeletar = _livroRepositorio.ObterPeloId(livroId);

            if (livroDeletar == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            _livroRepositorio.Deletar(livroDeletar);
        }

        public async Task<LivroResposta> ObterPeloIdAsync(int livroId)
        {
            var livroDominio = _livroRepositorio.ObterPeloId(livroId);

            if (livroDominio == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            var livro = new LivroResposta()
            {
                Id = livroDominio.Id,
                Titulo = livroDominio.Titulo,
                Autor = livroDominio.Autor,
                Sinopse = livroDominio.Sinopse,
                QuantidadeDePaginas = livroDominio.QuantidadeDePaginas,
                GeneroLiterario = livroDominio.GeneroLiterario
            };

            return livro;
        }

        public async Task<List<LivroResposta>> ListarAsync()
        {
            var livrosDominio = _livroRepositorio.Listar();

            if (livrosDominio == null)
            {
                throw new Exception("Não há livros para listar.");
            }

            var listaLivros = livrosDominio.Select(livro => new LivroResposta
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Sinopse = livro.Sinopse,
                QuantidadeDePaginas = livro.QuantidadeDePaginas,
                GeneroLiterario = livro.GeneroLiterario
            }).ToList();


            return listaLivros;
        }

        private static void ValidarInformacoesLivro(string titulo, string autor, int quantidadeDePaginas)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                throw new Exception("O título do livro não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(autor))
            {
                throw new Exception("O nome do(a) autor(a) não pode ser vazio.");
            }

            if (quantidadeDePaginas <= 0)
            {
                throw new Exception("A quantidade de páginas do livro não pode ser negativa.");
            }
        }
    }
}