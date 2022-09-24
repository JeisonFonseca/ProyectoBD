using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers.Catalogos
{
    public class ProbabilidadsController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public ProbabilidadsController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: Probabilidads
        public async Task<IActionResult> Index()
        {
              return View(await _context.Probabilidads.ToListAsync());
        }

        // GET: Probabilidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Probabilidads == null)
            {
                return NotFound();
            }

            var probabilidad = await _context.Probabilidads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (probabilidad == null)
            {
                return NotFound();
            }

            return View(probabilidad);
        }

        // GET: Probabilidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Probabilidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor")] Probabilidad probabilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probabilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(probabilidad);
        }

        // GET: Probabilidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Probabilidads == null)
            {
                return NotFound();
            }

            var probabilidad = await _context.Probabilidads.FindAsync(id);
            if (probabilidad == null)
            {
                return NotFound();
            }
            return View(probabilidad);
        }

        // POST: Probabilidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor")] Probabilidad probabilidad)
        {
            if (id != probabilidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(probabilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProbabilidadExists(probabilidad.Id))
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
            return View(probabilidad);
        }

        // GET: Probabilidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Probabilidads == null)
            {
                return NotFound();
            }

            var probabilidad = await _context.Probabilidads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (probabilidad == null)
            {
                return NotFound();
            }

            return View(probabilidad);
        }

        // POST: Probabilidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Probabilidads == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.Probabilidads'  is null.");
            }
            var probabilidad = await _context.Probabilidads.FindAsync(id);
            if (probabilidad != null)
            {
                _context.Probabilidads.Remove(probabilidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProbabilidadExists(int id)
        {
          return _context.Probabilidads.Any(e => e.Id == id);
        }
    }
}
