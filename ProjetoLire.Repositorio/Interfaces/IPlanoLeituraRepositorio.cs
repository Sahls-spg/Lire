using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Interfaces
{
    public interface IPlanoLeituraRepositorio
    {
        public int Criar(PlanoLeitura planoLeitura);
        public PlanoLeitura ObterPeloId(int planoLeituraId);
        public List<PlanoLeitura> ListarPorUsuario(int usuarioId);
        public List<PlanoLeitura> Listar();
    }
}