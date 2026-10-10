using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILivroBibliotecaAplicacao
    {
        public Task<List<Livro>> ListarPorUsuarioAsync(int usuarioId);
        public Task<List<Livro>> ListarPorStatusAsync(int usuarioId, StatusLeitura statusLeitura);
    }
}