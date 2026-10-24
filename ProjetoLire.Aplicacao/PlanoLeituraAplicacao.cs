using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class PlanoLeituraAplicacao : IPlanoLeituraAplicacao
    {
        readonly IPlanoLeituraRepositorio _planoLeituraRepositorio;

        public PlanoLeituraAplicacao(IPlanoLeituraRepositorio planoLeituraRepositorio)
        {
            _planoLeituraRepositorio = planoLeituraRepositorio;
        }

        public async Task<int> CriarAsync(PlanoLeituraCriar planoLeitura)
        {
            if (planoLeitura == null)
            {
                throw new Exception("O plano de leitura não pode ser vazio.");
            }

            ValidarPlanoLeitura(planoLeitura.LivroId, planoLeitura.PaginasPorDia, planoLeitura.DiasDisponiveisParaLer);

            var planoLeituraDominio = new PlanoLeitura()
            {
                UsuarioId = planoLeitura.UsuarioId,
                LivroId = planoLeitura.LivroId,
                DataInicio = planoLeitura.DataInicio,
                TempoDiarioPraLer = planoLeitura.TempoDiarioPraLer,
                DiasDisponiveisParaLer = planoLeitura.DiasDisponiveisParaLer,
                PaginasPorDia = planoLeitura.PaginasPorDia,
                DataPrevisaoTermino = planoLeitura.DataPrevisaoTermino
            };

            _planoLeituraRepositorio.Criar(planoLeituraDominio);

            return planoLeituraDominio.Id;
        }

        public async Task<PlanoLeituraResposta> ObterPeloIdAsync(int planoLeituraId)
        {
            var planoLeituraDominio = _planoLeituraRepositorio.ObterPeloId(planoLeituraId);

            if (planoLeituraDominio == null)
            {
                throw new Exception("O plano de leitura não encontrado.");
            }

            var planoLeitura = new PlanoLeituraResposta()
            {
                Id = planoLeituraDominio.Id,
                UsuarioId = planoLeituraDominio.UsuarioId,
                LivroId = planoLeituraDominio.LivroId,
                DataInicio = planoLeituraDominio.DataInicio,
                TempoDiarioPraLer = planoLeituraDominio.TempoDiarioPraLer,
                DiasDisponiveisParaLer = planoLeituraDominio.DiasDisponiveisParaLer,
                PaginasPorDia = planoLeituraDominio.PaginasPorDia,
                DataPrevisaoTermino = planoLeituraDominio.DataPrevisaoTermino
            };

            return planoLeitura;
        }

        public async Task<List<PlanoLeituraResposta>> ListarAsync()
        {
            var planosLeituraDominio = _planoLeituraRepositorio.Listar();

            if (planosLeituraDominio == null)
            {
                throw new Exception("Não há planos de leitura para listar.");
            }

            var planosLeitura = planosLeituraDominio.Select(plano => new PlanoLeituraResposta()
            {
                Id = plano.Id,
                UsuarioId = plano.UsuarioId,
                LivroId = plano.LivroId,
                DataInicio = plano.DataInicio,
                TempoDiarioPraLer = plano.TempoDiarioPraLer,
                DiasDisponiveisParaLer = plano.DiasDisponiveisParaLer,
                PaginasPorDia = plano.PaginasPorDia,
                DataPrevisaoTermino = plano.DataPrevisaoTermino
            }).ToList();

            return planosLeitura;
        }

        public async Task<List<PlanoLeituraResposta>> ListarPorUsuarioAsync(int usuarioId)
        {
            var planosLeituraDominio = _planoLeituraRepositorio.ListarPorUsuario(usuarioId);

            if (planosLeituraDominio == null)
            {
                throw new Exception("Esse usuário não tem planos de leitura");
            }

            var planosLeitura = planosLeituraDominio.Select(planoUsuario => new PlanoLeituraResposta()
            {
                Id = planoUsuario.Id,
                UsuarioId = planoUsuario.UsuarioId,
                LivroId = planoUsuario.LivroId,
                DataInicio = planoUsuario.DataInicio,
                TempoDiarioPraLer = planoUsuario.TempoDiarioPraLer,
                DiasDisponiveisParaLer = planoUsuario.DiasDisponiveisParaLer,
                PaginasPorDia = planoUsuario.PaginasPorDia,
                DataPrevisaoTermino = planoUsuario.DataPrevisaoTermino
            }).ToList();

            return planosLeitura;
        }

        private static void ValidarPlanoLeitura(int livroId, int paginasPorDia, int diasDisponiveisParaLer)
        {
            if (livroId < 0)
            {
                throw new Exception("O livro que deseja fazer uma plano de leitura não pode ser vazio.");
            }

            if (paginasPorDia <= 0)
            {
                throw new Exception("A quantidade de páginas lidas por dia não pode ser negativa.");
            }

            if (diasDisponiveisParaLer <= 0)
            {
                throw new Exception("A quantidade de dias disponíveis para ler não pode ser negativa.");
            }
        }
    }
}