using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class LivroBibliotecaAplicacao : ILivroBibliotecaAplicacao
    {
        readonly ILivroBibliotecaRepositorio _bibliotecaRepositorio;

        public LivroBibliotecaAplicacao(ILivroBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public async Task<List<LivroBiblioteca>> ListarPorUsuarioAsync(int usuarioId)
        {
            var livrosUsuario = _bibliotecaRepositorio.ListarPorUsuario(usuarioId);

            if(livrosUsuario == null)
            {
                throw new Exception("Esse usuário não tem nenhum livro em sua biblioteca.");
            }

            return livrosUsuario;
        }

        public async Task<List<LivroBiblioteca>> ListarPorStatusAsync(int usuarioId, StatusLeitura statusLeitura)
        {
            var livrosStatus = _bibliotecaRepositorio.ListarPorStatus(usuarioId, statusLeitura);

            if(livrosStatus == null)
            {
                throw new Exception("Esse usuário não tem nenhum livro com esse status em sua biblioteca.");
            }

            return livrosStatus;
        }
    }
}