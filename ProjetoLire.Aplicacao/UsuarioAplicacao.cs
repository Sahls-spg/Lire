using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<int> CriarAsync(UsuarioCriar usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Usuário não pode ser vazio.");
            }

            ValidarInformacoesUsuario(usuario.Nome, usuario.Sobrenome, usuario.Email);

            if (string.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("A senha não pode ser vazia.");
            }

            var usuarioDominio = new Usuario
            {
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Genero = usuario.Genero,
                Email = usuario.Email,
                Senha = usuario.Senha,
                QuantidadeDeLivrosLidos = usuario.QuantidadeLivrosLidos,
                GenerosLiterariosFavorito = usuario.GenerosLiterariosFavorito,
                DataNascimento = usuario.DataNascimento
            };

            var usuarioId = _usuarioRepositorio.Criar(usuarioDominio);

            return usuarioId;
        }

        public async Task AtualizarAsync(UsuarioAtualizar usuario)
        {
            var usuarioDominio = _usuarioRepositorio.ObterPeloId(usuario.Id);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            ValidarInformacoesUsuario(usuario.Nome, usuario.Sobrenome, usuario.Email);

            usuarioDominio.Id = usuario.Id;
            usuarioDominio.Nome = usuario.Nome;
            usuarioDominio.Sobrenome = usuario.Sobrenome;
            usuarioDominio.Email = usuario.Email;
            usuarioDominio.DataNascimento = usuario.DataNascimento;

            _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public async Task DeletarAsync(int usuarioId)
        {

            var usuarioDeletar = _usuarioRepositorio.ObterPeloId(usuarioId);

            if (usuarioDeletar == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            _usuarioRepositorio.Deletar(usuarioDeletar);
        }

        public async Task<UsuarioResposta> ObterPeloIdAsync(int usuarioId)
        {
            var usuarioDominio = _usuarioRepositorio.ObterPeloId(usuarioId);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var usuarioObter = new UsuarioResposta()
            {
                Id = usuarioDominio.Id,
                Nome = usuarioDominio.Nome,
                Sobrenome = usuarioDominio.Sobrenome,
                Genero = usuarioDominio.Genero,
                Email = usuarioDominio.Email,
                QuantidadeLivrosLidos = usuarioDominio.QuantidadeDeLivrosLidos,
                DataNascimento = usuarioDominio.DataNascimento,
                DataCriacaoDaConta = usuarioDominio.DataCriacaoDaConta,
                GenerosLiterariosFavorito = usuarioDominio.GenerosLiterariosFavorito
            };

            return usuarioObter;
        }

        public async Task<Usuario> ObterPeloEmailAsync(string email)
        {
            var usuarioDominio = _usuarioRepositorio.ObterPeloEmail(email);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            return usuarioDominio;
        }

        public async Task<List<UsuarioResposta>> ListarAsync()
        {
            var listaUsuariosDominio = _usuarioRepositorio.Listar();

            if (listaUsuariosDominio == null)
            {
                throw new Exception("Não há usuários para listar.");
            }

            var listaUsuarios = listaUsuariosDominio
                .Select(usuario => new UsuarioResposta()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    Genero = usuario.Genero,
                    Email = usuario.Email,
                    QuantidadeLivrosLidos = usuario.QuantidadeDeLivrosLidos,
                    DataNascimento = usuario.DataNascimento,
                    DataCriacaoDaConta = usuario.DataCriacaoDaConta,
                    GenerosLiterariosFavorito = usuario.GenerosLiterariosFavorito
                })
                .ToList();

            return listaUsuarios;
        }

        private static void ValidarInformacoesUsuario(string nome, string sobrenome, string email)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("O nome não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(sobrenome))
            {
                throw new Exception("O sobrenome não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("O e-mail não pode ser vazio.");
            }
        }
    }
}