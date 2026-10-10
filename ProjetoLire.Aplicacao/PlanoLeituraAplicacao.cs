using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class PlanoLeituraAplicacao
    {
        readonly IPlanoLeituraRepositorio _planoLeituraRepositorio;

        public PlanoLeituraAplicacao(IPlanoLeituraRepositorio planoLeituraRepositorio)
        {
            _planoLeituraRepositorio = planoLeituraRepositorio;
        }

        public async Task<int> CriarAsync(PlanoLeitura planoLeitura)
        {
            if(planoLeitura == null)
            {
                throw new Exception("O plano de leitura não pode ser vazio.");
            }

            ValidarPlanoLeitura(planoLeitura);

            _planoLeituraRepositorio.Criar(planoLeitura);

            return planoLeitura.Id;
        }

        public async Task<PlanoLeitura> ObterPeloIdAsync(int planoLeituraId)
        {
            var planoLeituraDominio = _planoLeituraRepositorio.ObterPeloId(planoLeituraId);

            if(planoLeituraDominio == null)
            {
                throw new Exception("O plano de leitura não encontrado.");
            }

            return planoLeituraDominio;
        }

        public async Task<List<PlanoLeitura>> ListarAsync()
        {
            var planosLeitura = _planoLeituraRepositorio.Listar();

            if(planosLeitura == null)
            {
                throw new Exception("Não há planos de leitura para listar.");
            }

            return planosLeitura;
        }

        public async Task<List<PlanoLeitura>> ListarPorUsuarioAsync(int usuarioId)
        {
            var planosLeitura = _planoLeituraRepositorio.ListarPorUsuario(usuarioId);

            if(planosLeitura == null)
            {
                throw new Exception("Esse usuário não tem planos de leitura");
            }

            return planosLeitura;
        }

        private static void ValidarPlanoLeitura(PlanoLeitura planoLeitura)
        {
            if(planoLeitura.Livro == null)
            {
                throw new Exception("O livro que deseja fazer uma plano de leitura não pode ser vazio.");
            }

            if(planoLeitura.PaginasPorDia <= 0)
            {
                throw new Exception("A quantidade de páginas lidas por dia não pode ser negativa.");
            }

            if(planoLeitura.DiasDisponiveisParaLer <= 0)
            {
                throw new Exception("A quantidade de dias disponíveis para ler não pode ser negativa.");
            }
        }
    }
}