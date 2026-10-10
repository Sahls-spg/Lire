using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Aplicacao.Interfaces
{
    public interface ILeituraAplicacao
    {
        public Task<int> RegistrarAsync(Leitura leitura);
        public Task AtualizarAsync(Leitura leitura);
        public Task<Leitura> ListarAsync();
        public Task<Leitura> ListarPorUsuarioAsync(int usuarioId);
    }
}