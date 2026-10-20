using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.DTO;
using ProjetoLire.Aplicacao.Interfaces;

namespace ProjetoLire.API.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly ILoginAplicacao _loginAplicacao;

        public LoginController(ILoginAplicacao loginAplicacao)
        {
            _loginAplicacao = loginAplicacao;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequisicao loginRequisicao)
        {
            try
            {
                var token = await _loginAplicacao.LoginAsync(loginRequisicao);

                if(token == null)
                {
                    return Unauthorized();
                }
                
                return Ok(token);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}