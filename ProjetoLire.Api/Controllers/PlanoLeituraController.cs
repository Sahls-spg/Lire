using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.Interfaces;

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
    }
}