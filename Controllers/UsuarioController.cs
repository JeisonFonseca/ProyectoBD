using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            return View(await _context.UsuariosViews.ToListAsync()); // Aqui quiero meter el encargadoDepartamento para mostrarlo en la vista
        }

        // GET: ActividadManoObras/Create
        public IActionResult Create()
        {
            List<Rol> listaRoles = new List<Rol>();
            listaRoles = (from rol in _context.Rols select new Rol { Id = rol.Id, Nombre = rol.Nombre }).ToList();
            listaRoles.Insert(0, new Rol { Id=0, Nombre = "Seleccione un rol" });
            ViewBag.messageRoles = listaRoles;
            return View();
        }


        /**
          * Funcion encargada de crear los departamentos
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,NombreUsuario,Clave,Nombre,Apellido1,Apelllido2, Rol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

    }
}
