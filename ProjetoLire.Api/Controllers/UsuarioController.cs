using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Aplicacao.Interfaces;

namespace ProjetoLire.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] UsuarioCriar usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    Senha = usuario.Senha
                };

                var usuarioId = await _usuarioAplicacao.CriarAsync(usuarioDominio);
                return Ok(usuarioId);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] UsuarioAtualizar usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email
                };

                await _usuarioAplicacao.AtualizarAsync(usuarioDominio);
                return Ok();
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> Deletar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.DeletarAsync(usuarioId);
                return Ok();
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet]
        [Route("ObterPeloId/{usuarioId}")]
        public async Task<ActionResult> ObterPeloId([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ObterPeloIdAsync(usuarioId);

                var usuario = new UsuarioResposta()
                {
                    Id = usuarioDominio.Id,
                    Nome = usuarioDominio.Nome,
                    Sobrenome = usuarioDominio.Sobrenome,
                    DataNascimento = usuarioDominio.DataNascimento,
                    Email = usuarioDominio.Email,
                    Genero = usuarioDominio.Genero,
                    DataCriacaoDaConta = usuarioDominio.DataCriacaoDaConta,
                    GenerosLiterariosFavorito = usuarioDominio.GenerosLiterariosFavorito
                };
                return Ok(usuario);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet]
        [Route("ObterPeloEmail/{email}")]
        public async Task<ActionResult> ObterPeloEmail([FromRoute] string email)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ObterPeloEmail(email);

                var usuario = new UsuarioResposta()
                {
                    Id = usuarioDominio.Id,
                    Nome = usuarioDominio.Nome,
                    Sobrenome = usuarioDominio.Sobrenome,
                    DataNascimento = usuarioDominio.DataNascimento,
                    Email = usuarioDominio.Email,
                    Genero = usuarioDominio.Genero,
                    DataCriacaoDaConta = usuarioDominio.DataCriacaoDaConta,
                    GenerosLiterariosFavorito = usuarioDominio.GenerosLiterariosFavorito
                };
                return Ok(usuario);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var usuariosDominio = await _usuarioAplicacao.ListarAsync();
                var usuarios = usuariosDominio.Select(usuario => new UsuarioResposta()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    Genero = usuario.Genero,
                    DataCriacaoDaConta = usuario.DataCriacaoDaConta,
                    GenerosLiterariosFavorito = usuario.GenerosLiterariosFavorito
                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}