using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILeituraAplicacao
    {
        public Task<int> RegistrarAsync(Leitura leitura);
        public Task AtualizarAsync(Leitura leitura);
        public Task<List<Leitura>> ListarAsync();
        public Task<List<Leitura>> ListarPorUsuarioAsync(int usuarioId);
    }
}