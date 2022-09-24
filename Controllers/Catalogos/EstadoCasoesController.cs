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
    public class EstadoCasoesController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public EstadoCasoesController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: EstadoCasoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.EstadoCasos.ToListAsync());
        }

        // GET: EstadoCasoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadoCasos == null)
            {
                return NotFound();
            }

            var estadoCaso = await _context.EstadoCasos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoCaso == null)
            {
                return NotFound();
            }

            return View(estadoCaso);
        }

        // GET: EstadoCasoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoCasoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EstadoCaso estadoCaso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoCaso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoCaso);
        }

        // GET: EstadoCasoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadoCasos == null)
            {
                return NotFound();
            }

            var estadoCaso = await _context.EstadoCasos.FindAsync(id);
            if (estadoCaso == null)
            {
                return NotFound();
            }
            return View(estadoCaso);
        }

        // POST: EstadoCasoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EstadoCaso estadoCaso)
        {
            if (id != estadoCaso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoCaso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoCasoExists(estadoCaso.Id))
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
            return View(estadoCaso);
        }

        // GET: EstadoCasoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadoCasos == null)
            {
                return NotFound();
            }

            var estadoCaso = await _context.EstadoCasos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoCaso == null)
            {
                return NotFound();
            }

            return View(estadoCaso);
        }

        // POST: EstadoCasoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadoCasos == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.EstadoCasos'  is null.");
            }
            var estadoCaso = await _context.EstadoCasos.FindAsync(id);
            if (estadoCaso != null)
            {
                _context.EstadoCasos.Remove(estadoCaso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoCasoExists(int id)
        {
          return _context.EstadoCasos.Any(e => e.Id == id);
        }
    }
}
