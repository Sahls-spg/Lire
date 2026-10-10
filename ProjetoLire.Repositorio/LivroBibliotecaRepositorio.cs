using Microsoft.EntityFrameworkCore;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Repositorio
{
    public class BibliotecaRepositorio : BaseRepositorio, ILivroBibliotecaRepositorio
    {
        public BibliotecaRepositorio(ProjetoLireContexto contexto) : base(contexto)
        {

        }

        public List<LivroBiblioteca> ListarPorUsuario(int usuarioId)
        {
            return _contexto.Livros_Bibliotecas.Where(biblioteca => biblioteca.UsuarioId == usuarioId).Include(biblioteca => biblioteca.Livro).ToList();
        }

        public List<LivroBiblioteca> ListarPorStatus(int usuarioId, StatusLeitura statusLeitura)
        {
            return _contexto.Livros_Bibliotecas.Where(biblioteca => biblioteca.UsuarioId == usuarioId && biblioteca.StatusLeitura == statusLeitura).Include(biblioteca => biblioteca.Livro).ToList();
        }
    }
}