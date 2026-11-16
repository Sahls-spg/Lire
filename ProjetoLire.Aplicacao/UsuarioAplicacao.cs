using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;
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

        public async Task CriarAsync(UsuarioCriar usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Usuário não pode ser vazio.");
            }

            if (usuario.DiasDisponiveisParaLer <= 0)
            {
                throw new Exception("A quantidade de dias disponíveis para ler não pode ser negativa.");
            }

            ValidarInformacoesUsuario(usuario.Nome, usuario.Sobrenome, usuario.Email, usuario.DataNascimento);

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
                TempoDiarioPraLer = usuario.TempoDiarioPraLer,
                DiasDisponiveisParaLer = usuario.DiasDisponiveisParaLer,
                GenerosLiterariosFavorito = usuario.GenerosLiterariosFavorito,
                DataNascimento = usuario.DataNascimento
            };

            await _usuarioRepositorio.Criar(usuarioDominio);
        }

        public async Task AtualizarAsync(UsuarioAtualizar usuario)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPeloId(usuario.Id);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            ValidarInformacoesUsuario(usuario.Nome, usuario.Sobrenome, usuario.Email, usuario.DataNascimento);

            usuarioDominio.Id = usuario.Id;
            usuarioDominio.Nome = usuario.Nome;
            usuarioDominio.Sobrenome = usuario.Sobrenome;
            usuarioDominio.Email = usuario.Email;
            usuarioDominio.DataNascimento = usuario.DataNascimento;

            await _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public async Task DeletarAsync(int usuarioId)
        {

            var usuarioDeletar = await _usuarioRepositorio.ObterPeloId(usuarioId);

            if (usuarioDeletar == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

           await _usuarioRepositorio.Deletar(usuarioDeletar);
        }

        public async Task<UsuarioResposta> ObterPeloIdAsync(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPeloId(usuarioId);

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
                TempoDiarioPraLer = usuarioDominio.TempoDiarioPraLer,
                DiasDisponiveisParaLer = usuarioDominio.DiasDisponiveisParaLer,
                DataNascimento = usuarioDominio.DataNascimento,
                DataCriacaoDaConta = usuarioDominio.DataCriacaoDaConta,
                GenerosLiterariosFavorito = usuarioDominio.GenerosLiterariosFavorito
            };

            return usuarioObter;
        }

        public async Task<Usuario> ObterPeloEmailAsync(string email)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPeloEmail(email);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            return usuarioDominio;
        }

        public async Task<List<Usuario>> ListarAsync()
        {
            var listaUsuariosDominio = _usuarioRepositorio.Listar();

            if (listaUsuariosDominio == null)
            {
                throw new Exception("Não há usuários para listar.");
            }

            return await listaUsuariosDominio;
        }

        public async Task<List<Genero>> ListarGeneros()
        {
            var generos = _usuarioRepositorio.ListarGeneros();
            return generos;
        }

        public async Task<List<GeneroLiterario>> ListarGenerosLiterarios()
        {
            var generosLiterarios = _usuarioRepositorio.ListarGenerosLiterarios();
            return generosLiterarios;
        }

        private static void ValidarInformacoesUsuario(string nome, string sobrenome, string email, DateOnly dataNascimento)
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

            if(dataNascimento > DateOnly.FromDateTime(DateTime.Now.Date))
            {
                throw new Exception("A data de nascimento não pode ser maior que a data de hoje.");
            }
        }
    }
}