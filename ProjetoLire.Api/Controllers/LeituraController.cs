using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}