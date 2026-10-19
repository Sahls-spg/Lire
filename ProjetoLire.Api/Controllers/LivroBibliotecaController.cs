using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoLire.Aplicacao.Interfaces;

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
    }
}