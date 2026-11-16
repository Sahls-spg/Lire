using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public Task Criar(Usuario usuario);
        public Task Atualizar(Usuario usuario);
        public Task Deletar(Usuario usuario);
        public Task<Usuario> ObterPeloId(int usuarioId);
        public Task<Usuario> ObterPeloEmail(string email);
        public Task<List<Usuario>> Listar();
        public List<Genero> ListarGeneros();
        public List<GeneroLiterario> ListarGenerosLiterarios();
    }
}