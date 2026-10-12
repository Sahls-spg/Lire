using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface ILivroBibliotecaRepositorio
    {
        public List<LivroBiblioteca> ListarPorUsuario(int usuarioId);
        public List<LivroBiblioteca> ListarPorStatus(int usuarioId, StatusLeitura statusLeitura);
    }
}