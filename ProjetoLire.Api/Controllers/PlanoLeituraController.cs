using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PlanoLeituraController : ControllerBase
    {
        private readonly IPlanoLeituraAplicacao _planoLeituraAplicacao;

        public PlanoLeituraController(IPlanoLeituraAplicacao planoLeituraAplicacao)
        {
            _planoLeituraAplicacao = planoLeituraAplicacao;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] PlanoLeituraCriar planoLeitura)
        {
            try
            {
                var planoLeituraId = await _planoLeituraAplicacao.CriarAsync(planoLeitura);
                return Ok(planoLeituraId);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet]
        [Route("Obter/{planoLeituraId}")]
        public async Task<ActionResult> Obter([FromRoute] int planoLeituraId)
        {
            try
            {
                var planoLeitura = await _planoLeituraAplicacao.ObterPeloIdAsync(planoLeituraId);
                return Ok(planoLeitura);
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
                var planosLeitura = await _planoLeituraAplicacao.ListarAsync();
                return Ok(planosLeitura);
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
                var planosLeitura = await _planoLeituraAplicacao.ListarPorUsuarioAsync(usuarioId);
                return Ok(planosLeitura);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}