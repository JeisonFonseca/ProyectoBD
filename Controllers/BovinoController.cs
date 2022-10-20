using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class BovinoController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public BovinoController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        // GET: Adquisión
        public async Task<IActionResult> Index()
        {
            return View(await _context.VistaBovinos.ToListAsync());
        }
    }
}
