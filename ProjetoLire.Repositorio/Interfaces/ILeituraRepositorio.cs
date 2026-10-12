using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface ILeituraRepositorio
    {
        public int Registrar(Leitura leitura);
        public void Atualizar(Leitura leitura);
        public Leitura ObterPeloId(int leituraId);
        public List<Leitura> ListarPorUsuario(int usuarioId);
        public List<Leitura> Listar();
    }
}