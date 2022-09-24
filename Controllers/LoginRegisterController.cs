using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class LoginRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
