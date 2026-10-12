using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Repositorio
{
    public class PlanoLeituraRepositorio : BaseRepositorio, IPlanoLeituraRepositorio
    {
        public PlanoLeituraRepositorio(ProjetoLireContexto contexto) :base(contexto)
        {
             
        }

        public int Criar(PlanoLeitura planoLeitura)
        {
            _contexto.Planos_De_Leitura.Add(planoLeitura);
            _contexto.SaveChanges();

            return planoLeitura.Id;
        }

        public PlanoLeitura ObterPeloId(int planoLeituraId)
        {
            return _contexto.Planos_De_Leitura.Where(planoLeitura => planoLeitura.Id == planoLeituraId).FirstOrDefault();
        }

        public List<PlanoLeitura> Listar()
        {
            return _contexto.Planos_De_Leitura.ToList();
        }

        public List<PlanoLeitura> ListarPorUsuario(int usuarioId)
        {
            return _contexto.Planos_De_Leitura.Where(planoLeitura => planoLeitura.UsuarioId == usuarioId).ToList();
        }
    }
}