using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface IUsuarioAplicacao
    {
        public Task<int> CriarAsync(Usuario usuario);
        public Task AtualizarAsync(Usuario usuario);
        public Task DeletarAsync(int usuarioId);
        public Task<Usuario> ObterPeloIdAsync(int usuarioId);
        public Task<List<Usuario>> ListarAsync();
    }
}