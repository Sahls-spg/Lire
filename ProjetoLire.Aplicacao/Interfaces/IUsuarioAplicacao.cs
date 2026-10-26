using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface IUsuarioAplicacao
    {
        public Task<int> CriarAsync(UsuarioCriar usuario);
        public Task AtualizarAsync(UsuarioAtualizar usuario);
        public Task DeletarAsync(int usuarioId);
        public Task<UsuarioResposta> ObterPeloIdAsync(int usuarioId);
        public Task<Usuario> ObterPeloEmailAsync(string email);
        public Task<List<UsuarioResposta>> ListarAsync();
        public Task<List<Genero>> ListarGeneros();
        public Task<List<GeneroLiterario>> ListarGenerosLiterarios();
    }
}