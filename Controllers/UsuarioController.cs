using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.Models.ViewModels;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public UsuarioController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        /**
         * Funcion encargada de mostrar la informacion de los Empleados
         */
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync()); // Aqui quiero meter el encargadoDepartamento para mostrarlo en la vista
        }

        /**
          * Funcion encargada de crear los departamentos
         */
        public async Task<IActionResult> Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario()
                {
                    Cedula = model.Cedula,
                    Nombre = model.Nombre,
                    Apellido1 = model.Apellido1,
                    Apelllido2 = model.Apelllido2,
                    //Rol = model.Rol
                };

                List<Rol> listaRoles = new List<Rol>();
                listaRoles = (from rol in _context.Rols select new Rol { Id=rol.Id, Nombre=rol.Nombre}).ToList();
                listaRoles.Insert(0, new Rol { Nombre="Seleccione su rol: " });

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

    }
}
