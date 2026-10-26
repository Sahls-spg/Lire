using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public int Criar(Usuario usuario);
        public void Atualizar(Usuario usuario);
        public void Deletar(Usuario usuario);
        public Usuario ObterPeloId(int usuarioId);
        public Usuario ObterPeloEmail(string email);
        public List<Usuario> Listar();
        public List<Genero> ListarGeneros();
        public List<GeneroLiterario> ListarGenerosLiterarios();
    }
}