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
    public class TipoCasoesController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public TipoCasoesController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: TipoCasoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoCasos.ToListAsync());
        }

        // GET: TipoCasoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoCasos == null)
            {
                return NotFound();
            }

            var tipoCaso = await _context.TipoCasos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCaso == null)
            {
                return NotFound();
            }

            return View(tipoCaso);
        }

        // GET: TipoCasoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCasoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoCaso tipoCaso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCaso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCaso);
        }

        // GET: TipoCasoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoCasos == null)
            {
                return NotFound();
            }

            var tipoCaso = await _context.TipoCasos.FindAsync(id);
            if (tipoCaso == null)
            {
                return NotFound();
            }
            return View(tipoCaso);
        }

        // POST: TipoCasoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoCaso tipoCaso)
        {
            if (id != tipoCaso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCaso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCasoExists(tipoCaso.Id))
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
            return View(tipoCaso);
        }

        // GET: TipoCasoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoCasos == null)
            {
                return NotFound();
            }

            var tipoCaso = await _context.TipoCasos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCaso == null)
            {
                return NotFound();
            }

            return View(tipoCaso);
        }

        // POST: TipoCasoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoCasos == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.TipoCasos'  is null.");
            }
            var tipoCaso = await _context.TipoCasos.FindAsync(id);
            if (tipoCaso != null)
            {
                _context.TipoCasos.Remove(tipoCaso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCasoExists(int id)
        {
          return _context.TipoCasos.Any(e => e.Id == id);
        }
    }
}
