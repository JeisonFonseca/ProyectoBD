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
    public class RazasController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public RazasController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        // GET: Razas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Razas.ToListAsync());
        }

        // GET: Razas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Razas == null)
            {
                return NotFound();
            }

            var raza = await _context.Razas
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (raza == null)
            {
                return NotFound();
            }

            return View(raza);
        }

        // GET: Razas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Razas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Nombre")] Raza raza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raza);
        }

        // GET: Razas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Razas == null)
            {
                return NotFound();
            }

            var raza = await _context.Razas.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }
            return View(raza);
        }

        // POST: Razas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Nombre")] Raza raza)
        {
            if (id != raza.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RazaExists(raza.Identificador))
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
            return View(raza);
        }

        // GET: Razas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Razas == null)
            {
                return NotFound();
            }

            var raza = await _context.Razas
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (raza == null)
            {
                return NotFound();
            }

            return View(raza);
        }

        // POST: Razas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Razas == null)
            {
                return Problem("Entity set 'FincaLosLaurelesContext.Razas'  is null.");
            }
            var raza = await _context.Razas.FindAsync(id);
            if (raza != null)
            {
                _context.Razas.Remove(raza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RazaExists(int id)
        {
          return _context.Razas.Any(e => e.Identificador == id);
        }
    }
}
