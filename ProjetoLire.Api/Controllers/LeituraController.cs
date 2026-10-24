using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;

namespace ProjetoLire.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LeituraController : ControllerBase
    {
        private readonly ILeituraAplicacao _leituraAplicacao;

        public LeituraController(ILeituraAplicacao leituraAplicacao)
        {
            _leituraAplicacao = leituraAplicacao;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<ActionResult> Registrar([FromBody] LeituraCriar leitura)
        {
            try
            {
                var leituraId = await _leituraAplicacao.RegistrarAsync(leitura);
                return Ok(leituraId);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] LeituraAtualizar leitura)
        {
            try
            {
                await _leituraAplicacao.AtualizarAsync(leitura);
                return Ok();
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
                var leiturasDominio = await _leituraAplicacao.ListarAsync();
                return Ok(leiturasDominio);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet]
        [Route("ListarPorUsuario/{usuarioId}")]
        public async Task<ActionResult> ListarPorUsuario([FromRoute] int usuarioId)
        {
            try
            {
                var leituraUsuarioDominio = await _leituraAplicacao.ListarPorUsuarioAsync(usuarioId);
                return Ok(leituraUsuarioDominio);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}