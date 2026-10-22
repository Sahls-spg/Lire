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
                var livroDominio = new Livro()
                {
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    GeneroLiterario = livro.GeneroLiterario,
                    QuantidadeDePaginas = livro.QuantidadeDePaginas,
                    Sinopse = livro.Sinopse
                };

                var livroId = await _livroAplicacao.CadastrarAsync(livroDominio);
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
                var livroDominio = new Livro()
                {
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    GeneroLiterario = livro.GeneroLiterario,
                    QuantidadeDePaginas = livro.QuantidadeDePaginas,
                    Sinopse = livro.Sinopse
                };

                await _livroAplicacao.AtualizarAsync(livroDominio);
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
        [Route("Obter/{livroId}")]
        public async Task<ActionResult> Obter([FromRoute] int livroId)
        {
            try
            {
                var livroDominio = await _livroAplicacao.ObterPeloIdAsync(livroId);

                var livro = new LivroResposta()
                {
                    Id = livroDominio.Id,
                    Titulo = livroDominio.Titulo,
                    Autor = livroDominio.Autor,
                    GeneroLiterario = livroDominio.GeneroLiterario,
                    QuantidadeDePaginas = livroDominio.QuantidadeDePaginas,
                    Sinopse = livroDominio.Sinopse
                };
                return Ok(livro);
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
                var livros = livrosDominio.Select(livro => new LivroResposta()
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    GeneroLiterario = livro.GeneroLiterario,
                    QuantidadeDePaginas = livro.QuantidadeDePaginas,
                    Sinopse = livro.Sinopse
                }).ToList();

                return Ok(livros);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}