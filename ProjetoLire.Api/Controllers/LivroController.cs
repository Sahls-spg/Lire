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
    public class LivroController : ControllerBase
    {
        private readonly ILivroAplicacao _livroAplicacao;

        public LivroController(ILivroAplicacao livroAplicacao)
        {
            _livroAplicacao = livroAplicacao;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] LivroCriar livro)
        {
            try
            {
                var livroId = await _livroAplicacao.CadastrarAsync(livro);
                return Ok(livroId);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }     

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] LivroAtualizar livro)
        {
            try
            {
                await _livroAplicacao.AtualizarAsync(livro);
                return Ok();
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> Deletar([FromBody] int livroId)
        {
            try
            {
                await _livroAplicacao.DeletarAsync(livroId);
                return Ok();
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet]
        [Route("ObterPeloId/{livroId}")]
        public async Task<ActionResult> ObterPeloId([FromRoute] int livroId)
        {
            try
            {
                var livroDominio = await _livroAplicacao.ObterPeloIdAsync(livroId);
                return Ok(livroDominio);
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
                var livrosDominio = await _livroAplicacao.ListarAsync();

                return Ok(livrosDominio);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}