using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class LeituraAplicacao
    {
        readonly ILeituraRepositorio _leituraRepositorio;

        public LeituraAplicacao(ILeituraRepositorio leituraRepositorio)
        {
            _leituraRepositorio = leituraRepositorio;
        }

        public async Task<int> RegistrarAsync(Leitura leitura)
        {
            if(leitura == null)
            {
                throw new Exception("A leitura não pode ser vazia.");
            }

            ValidarInformacoesLeitura(leitura);

            _leituraRepositorio.Registrar(leitura);

            return leitura.Id;
        }

        public async Task AtualizarAsync(Leitura leitura)
        {
            var leituraDominio = _leituraRepositorio.ObterPeloId(leitura.Id);

            if(leituraDominio == null)
            {
                throw new Exception("A leitura não pode ser vazia.");
            }

            ValidarInformacoesLeitura(leitura);

            leituraDominio.PaginaAtual = leitura.PaginaAtual;
            leituraDominio.DataRegistro = leitura.DataRegistro;

            _leituraRepositorio.Atualizar(leitura);
        }

        public async Task<List<Leitura>> ListarAsync()
        {
            var listaLeituras = _leituraRepositorio.Listar();

            if(listaLeituras == null)
            {
                throw new Exception("Não há leituras para listar.");
            }

            return listaLeituras;
        }

        public async Task<List<Leitura>> ListarPorUsuarioAsync(int usuarioId)
        {
            var listaLeiturasUsuario = _leituraRepositorio.ListarPorUsuario(usuarioId);

            if(listaLeiturasUsuario == null)
            {
                throw new Exception("Esse usuário não tem leituras para listar.");
            }

            return listaLeiturasUsuario;
        }

        private static void ValidarInformacoesLeitura(Leitura leitura)
        {
            if(leitura.Usuario == null)
            {
                throw new Exception("O usuário não pode ser vazio.");
            }

            if(leitura.Livro == null)
            {
                throw new Exception("O livro não pode ser vazio.");
            }

            if(leitura.PaginaAtual <= 0)
            {
                throw new Exception("A página atual não pode ser negativa.");
            }
        }

    }
}