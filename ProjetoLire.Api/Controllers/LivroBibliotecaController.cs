using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LivroBibliotecaController : ControllerBase
    {
        private readonly ILivroBibliotecaAplicacao _livroBibliotecaAplicacao;

        public LivroBibliotecaController(ILivroBibliotecaAplicacao livroBibliotecaAplicacao)
        {
            _livroBibliotecaAplicacao = livroBibliotecaAplicacao;
        }

        [HttpGet]
        [Route("ListarPorUsuario/{usuarioId}")]
        public async Task<ActionResult> ListarPorUsuario([FromRoute] int usuarioId)
        {
            try
            {
                var livrosBibliotecaDominio = await _livroBibliotecaAplicacao.ListarPorUsuarioAsync(usuarioId);

                var livrosBibliotecaUsuario = livrosBibliotecaDominio.Select(livroBiblioteca => new LivroBibliotecaResposta()
                {
                    Id = livroBiblioteca.Id,
                    UsuarioId = livroBiblioteca.UsuarioId,
                    LivroId = livroBiblioteca.LivroId,
                    StatusLeitura = livroBiblioteca.StatusLeitura,
                    DataAdicionado = livroBiblioteca.DataAdicionado
                }).ToList();

                return Ok(livrosBibliotecaUsuario);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet]
        [Route("ListarPorStatus/{int usuarioId, StatusLeitura statusLeitura}")]
        public async Task<ActionResult> ListarPorStatus([FromRoute] int usuarioId, StatusLeitura statusLeitura)
        {
            try
            {
                var livrosStatusDominio = await _livroBibliotecaAplicacao.ListarPorStatusAsync(usuarioId, statusLeitura);

                var livrosStatusUsuario = livrosStatusDominio.Select(livroBiblioteca => new LivroBibliotecaResposta()
                {
                    Id = livroBiblioteca.Id,
                    UsuarioId = livroBiblioteca.UsuarioId,
                    LivroId = livroBiblioteca.LivroId,
                    StatusLeitura = livroBiblioteca.StatusLeitura,
                    DataAdicionado = livroBiblioteca.DataAdicionado
                }).ToList();

                return Ok(livrosStatusUsuario);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}