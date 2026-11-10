using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;
using ProjetoLire.Services;

namespace ProjetoLire.Aplicacao
{
    public class RecomendacaoIAAplicacao
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IGroqService _groqService;
        public RecomendacaoIAAplicacao(IUsuarioRepositorio usuarioRepositorio, IGroqService groqService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _groqService = groqService;
        }

        public async Task<string> GerarRecomendacoesAsync(int usuarioId)
        {
            var usuario = _usuarioRepositorio.ObterPeloId(usuarioId);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var recomendacoes = await _groqService.RecomendarLivrosAsync(usuario.DataNascimento, usuario.Genero, usuario.QuantidadeDeLivrosLidos, usuario.GenerosLiterariosFavorito, usuario.TempoDiarioPraLer, usuario.DiasDisponiveisParaLer);

            if(recomendacoes == null)
            {
                throw new Exception("Nenhuma recomendação de livro foi gerada.");
            }

            return recomendacoes;
        }
    }
}