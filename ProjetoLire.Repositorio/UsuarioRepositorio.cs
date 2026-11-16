using System.Data;
using System.Text.Json;
using Dapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task Criar(Usuario usuario)
        {
            var parametros = new { usuario.Nome, usuario.Sobrenome, usuario.DataNascimento, usuario.Genero, usuario.Email, usuario.Senha, QuantidadeLivrosLidos = usuario.QuantidadeDeLivrosLidos, usuario.DiasDisponiveisParaLer, TempoDiario = usuario.TempoDiarioPraLer, DataCriacaoConta = usuario.DataCriacaoDaConta, GenerosLiterariosFavorito = System.Text.Json.JsonSerializer.Serialize(usuario.GenerosLiterariosFavorito) };
            await _contexto.Database.GetDbConnection().ExecuteAsync("spCadastrarUsuario", parametros, commandType: CommandType.StoredProcedure);
        }

        public async Task Atualizar(Usuario usuario)
        {
            var parametros = new { UsuarioID = usuario.Id, NovoNome = usuario.Nome, NovoSobrenome = usuario.Sobrenome, NovoEmail = usuario.Email, NovaDataNascimento = usuario.DataNascimento };
            await _contexto.Database.GetDbConnection().ExecuteAsync("spAtualizarUsuario", parametros, commandType: CommandType.StoredProcedure);
        }

        public async Task Deletar(Usuario usuario)
        {
            var parametros = new { UsuarioID = usuario.Id };
            await _contexto.Database.GetDbConnection().ExecuteAsync("spDeletarUsuario", parametros, commandType: CommandType.StoredProcedure);
        }

        public async Task<Usuario> ObterPeloId(int usuarioId)
        {
            var parametros = new { UsuarioID = usuarioId };

            var usuarioBanco = await _contexto.Database.GetDbConnection().QueryFirstOrDefaultAsync("spObterUsuarioPorID", parametros, commandType: CommandType.StoredProcedure);

            if (usuarioBanco == null)
            {
                return null;
            }

            var usuario = new Usuario
            {
                Id = usuarioBanco.Id,
                Nome = usuarioBanco.Nome,
                Sobrenome = usuarioBanco.Sobrenome,
                Genero = (Genero)usuarioBanco.Genero,
                Email = usuarioBanco.Email,
                Senha = usuarioBanco.Senha,
                QuantidadeDeLivrosLidos = usuarioBanco.QuantidadeDeLivrosLidos,
                DiasDisponiveisParaLer = usuarioBanco.DiasDisponiveisParaLer,
                TempoDiarioPraLer = TimeOnly.FromTimeSpan(usuarioBanco.TempoDiarioPraLer),
                DataNascimento = DateOnly.FromDateTime(usuarioBanco.DataNascimento),
                DataCriacaoDaConta = DateOnly.FromDateTime(usuarioBanco.DataCriacaoDaConta),
                GenerosLiterariosFavorito = JsonSerializer.Deserialize<List<GeneroLiterario>>((string)usuarioBanco.GenerosLiterariosFavorito ?? "[]")
            };

            return usuario;
        }

        public async Task<Usuario> ObterPeloEmail(string email)
        {
            var parametros = new { Email = email };
            return await _contexto.Database.GetDbConnection().QueryFirstOrDefaultAsync<Usuario>("spObterUsuarioPeloEmail", parametros, commandType: CommandType.StoredProcedure);
        }
        public async Task<List<Usuario>> Listar()
        {
            var usuariosBanco = await _contexto.Database.GetDbConnection().QueryAsync<Usuario>("SELECT * FROM vwListarUsuarios");
            return usuariosBanco.ToList();
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