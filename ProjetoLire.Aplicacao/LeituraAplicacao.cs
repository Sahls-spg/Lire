using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class LeituraAplicacao : ILeituraAplicacao
    {
        readonly ILeituraRepositorio _leituraRepositorio;

        public LeituraAplicacao(ILeituraRepositorio leituraRepositorio)
        {
            _leituraRepositorio = leituraRepositorio;
        }

        public async Task<int> RegistrarAsync(LeituraCriar leitura)
        {
            if (leitura == null)
            {
                throw new Exception("A leitura não pode ser vazia.");
            }

            var leituraDominio = new Leitura()
            {
                UsuarioId = leitura.UsuarioId,
                LivroId = leitura.LivroId,
                PaginaAtual = leitura.PaginaAtual,
                DataRegistro = leitura.DataRegistro
            };

            _leituraRepositorio.Registrar(leituraDominio);

            return leituraDominio.Id;
        }

        public async Task AtualizarAsync(LeituraAtualizar leitura)
        {
            var leituraDominio = _leituraRepositorio.ObterPeloId(leitura.Id);

            if (leituraDominio == null)
            {
                throw new Exception("A leitura não pode ser vazia.");
            }

            if (leitura.PaginaAtual <= 0)
            {
                throw new Exception("A página atual do livro não pode ser negativa.");
            }

            leituraDominio.PaginaAtual = leitura.PaginaAtual;
            leituraDominio.DataRegistro = leitura.DataRegistro;

            _leituraRepositorio.Atualizar(leituraDominio);
        }

        public async Task<List<LeituraResposta>> ListarAsync()
        {
            var leiturasDominio = _leituraRepositorio.Listar();

            if (leiturasDominio == null)
            {
                throw new Exception("Não há leituras para listar.");
            }

            var leituras = leiturasDominio.Select(leitura => new LeituraResposta()
            {
                Id = leitura.Id,
                UsuarioId = leitura.UsuarioId,
                LivroId = leitura.LivroId,
                PaginaAtual = leitura.PaginaAtual,
                DataRegistro = leitura.DataRegistro
            }).ToList();

            return leituras;
        }

        public async Task<List<LeituraResposta>> ListarPorUsuarioAsync(int usuarioId)
        {
            var leiturasUsuarioDominio = _leituraRepositorio.ListarPorUsuario(usuarioId);

            if (leiturasUsuarioDominio == null)
            {
                throw new Exception("Esse usuário não tem leituras para listar.");
            }

            var leiturasUsuario = leiturasUsuarioDominio.Select(leitura => new LeituraResposta()
            {
                Id = leitura.Id,
                UsuarioId = leitura.UsuarioId,
                LivroId = leitura.LivroId,
                PaginaAtual = leitura.PaginaAtual,
                DataRegistro = leitura.DataRegistro
            }).ToList();

            return leiturasUsuario;
        }
    }
}