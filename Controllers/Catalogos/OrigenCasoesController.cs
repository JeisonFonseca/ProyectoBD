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
    public class OrigenCasoesController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public OrigenCasoesController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: OrigenCasoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.OrigenCasos.ToListAsync());
        }

        // GET: OrigenCasoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrigenCasos == null)
            {
                return NotFound();
            }

            var origenCaso = await _context.OrigenCasos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origenCaso == null)
            {
                return NotFound();
            }

            return View(origenCaso);
        }

        // GET: OrigenCasoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrigenCasoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] OrigenCaso origenCaso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(origenCaso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origenCaso);
        }

        // GET: OrigenCasoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrigenCasos == null)
            {
                return NotFound();
            }

            var origenCaso = await _context.OrigenCasos.FindAsync(id);
            if (origenCaso == null)
            {
                return NotFound();
            }
            return View(origenCaso);
        }

        // POST: OrigenCasoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] OrigenCaso origenCaso)
        {
            if (id != origenCaso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(origenCaso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrigenCasoExists(origenCaso.Id))
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
            return View(origenCaso);
        }

        // GET: OrigenCasoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrigenCasos == null)
            {
                return NotFound();
            }

            var origenCaso = await _context.OrigenCasos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origenCaso == null)
            {
                return NotFound();
            }

            return View(origenCaso);
        }

        // POST: OrigenCasoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrigenCasos == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.OrigenCasos'  is null.");
            }
            var origenCaso = await _context.OrigenCasos.FindAsync(id);
            if (origenCaso != null)
            {
                _context.OrigenCasos.Remove(origenCaso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrigenCasoExists(int id)
        {
          return _context.OrigenCasos.Any(e => e.Id == id);
        }
    }
}
