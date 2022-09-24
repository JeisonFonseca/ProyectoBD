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
    public class TipoCotizacionsController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public TipoCotizacionsController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: TipoCotizacions
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoCotizacions.ToListAsync());
        }

        // GET: TipoCotizacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoCotizacions == null)
            {
                return NotFound();
            }

            var tipoCotizacion = await _context.TipoCotizacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCotizacion == null)
            {
                return NotFound();
            }

            return View(tipoCotizacion);
        }

        // GET: TipoCotizacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCotizacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoCotizacion tipoCotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCotizacion);
        }

        // GET: TipoCotizacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoCotizacions == null)
            {
                return NotFound();
            }

            var tipoCotizacion = await _context.TipoCotizacions.FindAsync(id);
            if (tipoCotizacion == null)
            {
                return NotFound();
            }
            return View(tipoCotizacion);
        }

        // POST: TipoCotizacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoCotizacion tipoCotizacion)
        {
            if (id != tipoCotizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCotizacionExists(tipoCotizacion.Id))
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
            return View(tipoCotizacion);
        }

        // GET: TipoCotizacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoCotizacions == null)
            {
                return NotFound();
            }

            var tipoCotizacion = await _context.TipoCotizacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCotizacion == null)
            {
                return NotFound();
            }

            return View(tipoCotizacion);
        }

        // POST: TipoCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoCotizacions == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.TipoCotizacions'  is null.");
            }
            var tipoCotizacion = await _context.TipoCotizacions.FindAsync(id);
            if (tipoCotizacion != null)
            {
                _context.TipoCotizacions.Remove(tipoCotizacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCotizacionExists(int id)
        {
          return _context.TipoCotizacions.Any(e => e.Id == id);
        }
    }
}
