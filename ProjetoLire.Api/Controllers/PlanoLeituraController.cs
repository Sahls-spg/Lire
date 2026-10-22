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
                var planoLeituraDominio = new PlanoLeitura()
                {
                    UsuarioId = planoLeitura.UsuarioId,
                    LivroId = planoLeitura.LivroId,
                    DataInicio = planoLeitura.DataInicio,
                    TempoDiarioPraLer = planoLeitura.TempoDiarioPraLer,
                    DiasDisponiveisParaLer = planoLeitura.DiasDisponiveisParaLer,
                    PaginasPorDia = planoLeitura.PaginasPorDia,
                    DataPrevisaoTermino = planoLeitura.DataPrevisaoTermino
                };

                var planoLeituraId = await _planoLeituraAplicacao.CriarAsync(planoLeituraDominio);
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
                var planoLeituraDominio = await _planoLeituraAplicacao.ObterPeloIdAsync(planoLeituraId);

                var planoLeitura = new PlanoLeituraResposta()
                {
                    Id = planoLeituraDominio.Id,
                    UsuarioId = planoLeituraDominio.UsuarioId,
                    LivroId = planoLeituraDominio.LivroId,
                    DataInicio = planoLeituraDominio.DataInicio,
                    TempoDiarioPraLer = planoLeituraDominio.TempoDiarioPraLer,
                    DiasDisponiveisParaLer = planoLeituraDominio.DiasDisponiveisParaLer,
                    PaginasPorDia = planoLeituraDominio.PaginasPorDia,
                    DataPrevisaoTermino = planoLeituraDominio.DataPrevisaoTermino
                };

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
                var planosLeituraDominio = await _planoLeituraAplicacao.ListarAsync();

                var planos = planosLeituraDominio.Select(plano => new PlanoLeituraResposta()
                {
                    Id = plano.Id,
                    UsuarioId = plano.UsuarioId,
                    LivroId = plano.LivroId,
                    DataInicio = plano.DataInicio,
                    TempoDiarioPraLer = plano.TempoDiarioPraLer,
                    DiasDisponiveisParaLer = plano.DiasDisponiveisParaLer,
                    PaginasPorDia = plano.PaginasPorDia,
                    DataPrevisaoTermino = plano.DataPrevisaoTermino
                }).ToList();

                return Ok(planos);
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
                var planosLeituraDominio = await _planoLeituraAplicacao.ListarPorUsuarioAsync(usuarioId);

                var planosUsuario = planosLeituraDominio.Select(planoUsuario => new PlanoLeituraResposta()
                {
                    Id = planoUsuario.Id,
                    UsuarioId = planoUsuario.UsuarioId,
                    LivroId = planoUsuario.LivroId,
                    DataInicio = planoUsuario.DataInicio,
                    TempoDiarioPraLer = planoUsuario.TempoDiarioPraLer,
                    DiasDisponiveisParaLer = planoUsuario.DiasDisponiveisParaLer,
                    PaginasPorDia = planoUsuario.PaginasPorDia,
                    DataPrevisaoTermino = planoUsuario.DataPrevisaoTermino
                }).ToList();

                return Ok(planosUsuario);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}