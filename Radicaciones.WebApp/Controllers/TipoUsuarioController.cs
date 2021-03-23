using Microsoft.AspNetCore.Mvc;

namespace Radicaciones.WebApp.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}