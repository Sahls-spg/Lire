using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public int Criar(Usuario usuario);
        public void Atualizar(Usuario usuario);
        public void Deletar(Usuario usuario);
        public Usuario ObterPeloId(int usuarioId);
        public List<Usuario> Listar();
    }
}