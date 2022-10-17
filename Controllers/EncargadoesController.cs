using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class EncargadoesController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public EncargadoesController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        // GET: Encargadoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Encargados.ToListAsync());
        }

        // GET: Encargadoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Encargados == null)
            {
                return NotFound();
            }

            var encargado = await _context.Encargados
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (encargado == null)
            {
                return NotFound();
            }

            return View(encargado);
        }

        // GET: Encargadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encargadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,Nombre,Apellido1,Apelllido2,Contraseña")] Encargado encargado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encargado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encargado);
        }

        // GET: Encargadoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Encargados == null)
            {
                return NotFound();
            }

            var encargado = await _context.Encargados.FindAsync(id);
            if (encargado == null)
            {
                return NotFound();
            }
            return View(encargado);
        }

        // POST: Encargadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cedula,Nombre,Apellido1,Apelllido2,Contraseña")] Encargado encargado)
        {
            if (id != encargado.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encargado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncargadoExists(encargado.Cedula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(encargado);
        }

        // GET: Encargadoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Encargados == null)
            {
                return NotFound();
            }

            var encargado = await _context.Encargados
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (encargado == null)
            {
                return NotFound();
            }

            return View(encargado);
        }

        // POST: Encargadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Encargados == null)
            {
                return Problem("Entity set 'FincaLosLaurelesContext.Encargados'  is null.");
            }
            var encargado = await _context.Encargados.FindAsync(id);
            if (encargado != null)
            {
                _context.Encargados.Remove(encargado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncargadoExists(string id)
        {
          return _context.Encargados.Any(e => e.Cedula == id);
        }
    }
}
