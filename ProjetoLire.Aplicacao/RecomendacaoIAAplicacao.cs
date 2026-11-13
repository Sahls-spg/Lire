using System.Text.Json;
using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;
using ProjetoLire.Services;
using ProjetoLire.Services.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class RecomendacaoIAAplicacao : IRecomendacaoIAAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IGoogleBooksService _googleBooksService;
        private readonly IGroqService _groqService;
        public RecomendacaoIAAplicacao(IUsuarioRepositorio usuarioRepositorio, IGroqService groqService, IGoogleBooksService googleBooksService, ILivroRepositorio livroRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _groqService = groqService;
            _googleBooksService = googleBooksService;
            _livroRepositorio = livroRepositorio;
        }

        public async Task<List<Livro>> GerarRecomendacoesAsync(int usuarioId)
        {
            var usuario = _usuarioRepositorio.ObterPeloId(usuarioId);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var recomendacoesGroq = await _groqService.RecomendarLivrosAsync(usuario.DataNascimento, usuario.Genero, usuario.QuantidadeDeLivrosLidos, usuario.GenerosLiterariosFavorito, usuario.TempoDiarioPraLer, usuario.DiasDisponiveisParaLer);

            if (recomendacoesGroq == null)
            {
                throw new Exception("Nenhuma recomendação foi gerada.");
            }

            var livrosRecomendados = new List<Livro>();

            List<LivroRecomendado> recomendacoes = JsonSerializer.Deserialize<List<LivroRecomendado>>(recomendacoesGroq, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (recomendacoes == null)
            {
                throw new Exception("Não foi acessar as recomendações da IA.");
            }

            foreach (var recomendacao in recomendacoes)
            {
                if (string.IsNullOrWhiteSpace(recomendacao.Titulo) || string.IsNullOrWhiteSpace(recomendacao.Autor))
                {
                    continue;
                }

                var livroDominio = _livroRepositorio.ObterPeloTituloEAutor(recomendacao.Titulo, recomendacao.Autor);

                if (livroDominio != null)
                {
                    livrosRecomendados.Add(livroDominio);
                    continue;
                }

                var livrosGoogle = await _googleBooksService.BuscarLivrosAsync(recomendacao.Titulo, recomendacao.Autor);

                if (livrosGoogle == null || livrosGoogle.Count == 0)
                {
                    continue;
                }

                var volumeInfo = livrosGoogle[0].VolumeInfo;

                if (volumeInfo == null || string.IsNullOrWhiteSpace(volumeInfo.Title))
                {
                    continue;
                }

                var novoLivro = new Livro
                {
                    Titulo = volumeInfo.Title,
                    Autor = string.Join(", ", volumeInfo.Authors ?? new List<string>()),
                    GeneroLiterario = null,
                    QuantidadeDePaginas = volumeInfo.PageCount ?? 0,
                    Sinopse = volumeInfo.Description ?? "",
                    ImagemCapa = volumeInfo.ImageLinks?.Thumbnail ?? ""
                };

                _livroRepositorio.Cadastrar(novoLivro);

                livrosRecomendados.Add(novoLivro);
            }

            return livrosRecomendados;
        }
    }
}