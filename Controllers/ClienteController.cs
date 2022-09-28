using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ClienteController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public ClienteController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        /**
         * Funcion encargada de mostrar la informacion de los Empleados
         */
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientesViews.ToListAsync()); // Aqui quiero meter el encargadoDepartamento para mostrarlo en la vista
        }

        // GET: 
        public IActionResult Create()
        {
            List<Rol> listaRoles = new List<Rol>();
            listaRoles = (from rol in _context.Rols select new Rol { Id = rol.Id, Nombre = rol.Nombre }).ToList();
            listaRoles.Insert(0, new Rol { Id = 0, Nombre = "Seleccione un rol" });
            ViewBag.messageRoles = listaRoles;
            return View();
        }

        /**
          * Funcion encargada de crear los departamentos
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,NombreUsuario,Clave,Nombre,Apellido1,Apelllido2,Rol")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

    }
}
