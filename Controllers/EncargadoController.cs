using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class EncargadoController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public EncargadoController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        /**
         * Funcion encargada de mostrar la informacion de los Empleados
         */
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropiedadesBovinosDuenos.ToListAsync()); 
        }
    }
}
