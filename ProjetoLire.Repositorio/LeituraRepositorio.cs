using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Repositorio
{
    public class LeituraRepositorio : BaseRepositorio, ILeituraRepositorio
    {
        public LeituraRepositorio(ProjetoLireContexto contexto) :base(contexto)
        {
             
        }
        public int Registrar(Leitura leitura)
        {
            _contexto.Leituras.Add(leitura);
            _contexto.SaveChanges();

            return leitura.Id;
        }

        public void Atualizar(Leitura leitura)
        {
            _contexto.Leituras.Update(leitura);
            _contexto.SaveChanges();
        }

        public Leitura ObterPeloId(int leituraId)
        {
           return _contexto.Leituras.Where(leitura => leitura.Id == leituraId).FirstOrDefault();
        }

        public List<Leitura> Listar()
        {
            return _contexto.Leituras.ToList();
        }

        public List<Leitura> ListarPorUsuario(int usuarioId)
        {
            return _contexto.Leituras.Where(leitura => leitura.UsuarioId == usuarioId).ToList();
        }
    }
}