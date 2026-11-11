using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.Interfaces;

namespace ProjetoLire.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class RecomendacaoIAController : ControllerBase
    {
        private readonly IRecomendacaoIAAplicacao _recomendacaoAplicacao;

        public RecomendacaoIAController(IRecomendacaoIAAplicacao recomendacaoAplicacao)
        {
            _recomendacaoAplicacao = recomendacaoAplicacao;
        }

        [HttpPost]
        [Route("RecomendacaoLivro/{usuarioId}")]
        public async Task<IActionResult> GerarRecomendacoes([FromRoute] int usuarioId)
        {
            try
            {
                var recomendacoes = await _recomendacaoAplicacao.GerarRecomendacoesAsync(usuarioId);
                return Ok(recomendacoes);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}