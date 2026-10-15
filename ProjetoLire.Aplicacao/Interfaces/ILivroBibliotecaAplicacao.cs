using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILivroBibliotecaAplicacao
    {
        public Task<List<LivroBiblioteca>> ListarPorUsuarioAsync(int usuarioId);
        public Task<List<LivroBiblioteca>> ListarPorStatusAsync(int usuarioId, StatusLeitura statusLeitura);
    }
}