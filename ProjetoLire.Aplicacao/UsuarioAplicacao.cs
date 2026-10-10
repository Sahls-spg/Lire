using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class UsuarioAplicacao
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<int> CriarAsync(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new Exception("Usuário não pode ser vazio.");
            }

            ValidarInformacoesUsuario(usuario);

            return _usuarioRepositorio.Criar(usuario);
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            var usuarioDominio = _usuarioRepositorio.ObterPeloId(usuario.Id);

            if(usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            ValidarInformacoesUsuario(usuario);

            usuarioDominio.Nome = usuario.Nome;
            usuarioDominio.Sobrenome = usuario.Sobrenome;
            usuarioDominio.Email = usuario.Email;
            usuarioDominio.DataNascimento = usuario.DataNascimento;
            usuarioDominio.DataCriacaoDaConta = usuario.DataCriacaoDaConta;
            usuarioDominio.LivrosBiblioteca = usuario.LivrosBiblioteca;

            _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public async Task DeletarAsync(Usuario usuario)
        {

            var usuarioDeletar = _usuarioRepositorio.ObterPeloId(usuario.Id);

            if(usuarioDeletar == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            
            _usuarioRepositorio.Deletar(usuarioDeletar);
        }

        public async Task<Usuario> ObterPeloIdAsync(int usuarioId)
        {
            var usuarioDominio = _usuarioRepositorio.ObterPeloId(usuarioId);

            if(usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            return usuarioDominio;
        }

        public async Task<List<Usuario>> ListarAsync()
        {
            var listaUsuarios = _usuarioRepositorio.Listar();

            if(listaUsuarios == null)
            {
                throw new Exception("Não há usuários para listar.");
            }

            return listaUsuarios;
        }

        private static void ValidarInformacoesUsuario(Usuario usuario)
        {
            if(string.IsNullOrEmpty(usuario.Nome))
            {
                throw new Exception("O nome não pode ser vazio.");
            }

            if(string.IsNullOrEmpty(usuario.Sobrenome))
            {
                throw new Exception("O sobrenome não pode ser vazio.");
            }

            if(string.IsNullOrEmpty(usuario.Email))
            {
                throw new Exception("O e-mail não pode ser vazio.");
            }

            if(string.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("A senha não pode ser vazia.");
            }
        }
    }
}