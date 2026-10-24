using ProjetoLire.Aplicacao.DTO;
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

        public async Task<List<LivroBibliotecaResposta>> ListarPorUsuarioAsync(int usuarioId)
        {
            var livrosUsuario = _bibliotecaRepositorio.ListarPorUsuario(usuarioId);

            if (livrosUsuario == null)
            {
                throw new Exception("Esse usuário não tem nenhum livro em sua biblioteca.");
            }

            var livrosBibliotecaUsuario = livrosUsuario.Select(livroBiblioteca => new LivroBibliotecaResposta()
            {
                Id = livroBiblioteca.Id,
                UsuarioId = livroBiblioteca.UsuarioId,
                LivroId = livroBiblioteca.LivroId,
                StatusLeitura = livroBiblioteca.StatusLeitura,
                DataAdicionado = livroBiblioteca.DataAdicionado
            }).ToList();

            return livrosBibliotecaUsuario;
        }

        public async Task<List<LivroBibliotecaResposta>> ListarPorStatusAsync(int usuarioId, StatusLeitura statusLeitura)
        {
            var livrosStatus = _bibliotecaRepositorio.ListarPorStatus(usuarioId, statusLeitura);

            if (livrosStatus == null)
            {
                throw new Exception("Esse usuário não tem nenhum livro com esse status em sua biblioteca.");
            }

            var livrosBibliotecaUsuario = livrosStatus.Select(livroBiblioteca => new LivroBibliotecaResposta()
            {
                Id = livroBiblioteca.Id,
                UsuarioId = livroBiblioteca.UsuarioId,
                LivroId = livroBiblioteca.LivroId,
                StatusLeitura = livroBiblioteca.StatusLeitura,
                DataAdicionado = livroBiblioteca.DataAdicionado
            }).ToList();

            return livrosBibliotecaUsuario;
        }
    }
}