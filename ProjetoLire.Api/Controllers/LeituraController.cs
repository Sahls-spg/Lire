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
                var leituraDominio = new Leitura()
                {
                    UsuarioId = leitura.UsuarioId,
                    LivroId = leitura.LivroId,
                    PaginaAtual = leitura.PaginaAtual,
                    DataRegistro = leitura.DataRegistro
                };

                var leituraId = _leituraAplicacao.RegistrarAsync(leituraDominio);
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
                var leituraDominio = new Leitura()
                {
                    UsuarioId = leitura.UsuarioId,
                    LivroId = leitura.LivroId,
                    PaginaAtual = leitura.PaginaAtual,
                    DataRegistro = leitura.DataRegistro
                };

                await _leituraAplicacao.AtualizarAsync(leituraDominio);
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
                var leituraDominio = await _leituraAplicacao.ListarAsync();

                var leituras = leituraDominio.Select(leitura => new LeituraResposta()
                {
                    Id = leitura.Id,
                    UsuarioId = leitura.UsuarioId,
                    LivroId = leitura.LivroId,
                    PaginaAtual = leitura.PaginaAtual,
                    DataRegistro = leitura.DataRegistro
                }).ToList();

                return Ok(leituras);
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

                var leiturasUsuario = leituraUsuarioDominio.Select(leitura => new LeituraResposta()
                {
                    Id = leitura.Id,
                    UsuarioId = leitura.UsuarioId,
                    LivroId = leitura.LivroId,
                    PaginaAtual = leitura.PaginaAtual,
                    DataRegistro = leitura.DataRegistro
                }).ToList();

                return Ok(leiturasUsuario);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}