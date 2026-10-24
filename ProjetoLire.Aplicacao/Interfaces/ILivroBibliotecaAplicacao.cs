using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILivroBibliotecaAplicacao
    {
        public Task<List<LivroBibliotecaResposta>> ListarPorUsuarioAsync(int usuarioId);
        public Task<List<LivroBibliotecaResposta>> ListarPorStatusAsync(int usuarioId, StatusLeitura statusLeitura);
    }
}