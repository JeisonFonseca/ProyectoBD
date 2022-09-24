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
    public class PorQueSeDenegoesController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public PorQueSeDenegoesController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: PorQueSeDenegoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.PorQueSeDenegos.ToListAsync());
        }

        // GET: PorQueSeDenegoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PorQueSeDenegos == null)
            {
                return NotFound();
            }

            var porQueSeDenego = await _context.PorQueSeDenegos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porQueSeDenego == null)
            {
                return NotFound();
            }

            return View(porQueSeDenego);
        }

        // GET: PorQueSeDenegoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PorQueSeDenegoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] PorQueSeDenego porQueSeDenego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(porQueSeDenego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(porQueSeDenego);
        }

        // GET: PorQueSeDenegoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PorQueSeDenegos == null)
            {
                return NotFound();
            }

            var porQueSeDenego = await _context.PorQueSeDenegos.FindAsync(id);
            if (porQueSeDenego == null)
            {
                return NotFound();
            }
            return View(porQueSeDenego);
        }

        // POST: PorQueSeDenegoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] PorQueSeDenego porQueSeDenego)
        {
            if (id != porQueSeDenego.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(porQueSeDenego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PorQueSeDenegoExists(porQueSeDenego.Id))
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
            return View(porQueSeDenego);
        }

        // GET: PorQueSeDenegoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PorQueSeDenegos == null)
            {
                return NotFound();
            }

            var porQueSeDenego = await _context.PorQueSeDenegos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porQueSeDenego == null)
            {
                return NotFound();
            }

            return View(porQueSeDenego);
        }

        // POST: PorQueSeDenegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PorQueSeDenegos == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.PorQueSeDenegos'  is null.");
            }
            var porQueSeDenego = await _context.PorQueSeDenegos.FindAsync(id);
            if (porQueSeDenego != null)
            {
                _context.PorQueSeDenegos.Remove(porQueSeDenego);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorQueSeDenegoExists(int id)
        {
          return _context.PorQueSeDenegos.Any(e => e.Id == id);
        }
    }
}
