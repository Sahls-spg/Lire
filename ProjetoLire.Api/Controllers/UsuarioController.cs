using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.DTO;
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
                var usuarioId = await _usuarioAplicacao.CriarAsync(usuario);
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
                await _usuarioAplicacao.AtualizarAsync(usuario);
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
                return Ok(usuarioDominio);
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
                var usuarioDominio = await _usuarioAplicacao.ObterPeloEmailAsync(email);
                return Ok(usuarioDominio);
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
                return Ok(usuariosDominio);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}