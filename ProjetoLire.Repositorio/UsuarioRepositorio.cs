using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ProjetoLireContexto contexto) : base(contexto)
        {

        }
        
        public int Criar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();

            return usuario.Id;
        }

        public void Atualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }

        public void Deletar(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
        }

        public Usuario ObterPeloId(int usuarioId)
        {
            return _contexto.Usuarios.Where(usuario => usuario.Id == usuarioId).FirstOrDefault();
        }
        public Usuario ObterPeloEmail(string email)
        {
            return _contexto.Usuarios.Where(usuario => usuario.Email == email).FirstOrDefault();
        }
        public List<Usuario> Listar()
        {
            return _contexto.Usuarios.ToList();
        }

        public List<Genero> ListarGeneros()
        {
            return Enum.GetValues<Genero>().ToList();
        }

        public List<GeneroLiterario> ListarGenerosLiterarios()
        {
            return Enum.GetValues<GeneroLiterario>().ToList();
        }
    }
}