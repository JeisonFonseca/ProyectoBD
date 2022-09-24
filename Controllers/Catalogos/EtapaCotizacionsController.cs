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
    public class EtapaCotizacionsController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public EtapaCotizacionsController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: EtapaCotizacions
        public async Task<IActionResult> Index()
        {
              return View(await _context.EtapaCotizacions.ToListAsync());
        }

        // GET: EtapaCotizacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EtapaCotizacions == null)
            {
                return NotFound();
            }

            var etapaCotizacion = await _context.EtapaCotizacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etapaCotizacion == null)
            {
                return NotFound();
            }

            return View(etapaCotizacion);
        }

        // GET: EtapaCotizacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EtapaCotizacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EtapaCotizacion etapaCotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etapaCotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etapaCotizacion);
        }

        // GET: EtapaCotizacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EtapaCotizacions == null)
            {
                return NotFound();
            }

            var etapaCotizacion = await _context.EtapaCotizacions.FindAsync(id);
            if (etapaCotizacion == null)
            {
                return NotFound();
            }
            return View(etapaCotizacion);
        }

        // POST: EtapaCotizacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EtapaCotizacion etapaCotizacion)
        {
            if (id != etapaCotizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etapaCotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtapaCotizacionExists(etapaCotizacion.Id))
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
            return View(etapaCotizacion);
        }

        // GET: EtapaCotizacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EtapaCotizacions == null)
            {
                return NotFound();
            }

            var etapaCotizacion = await _context.EtapaCotizacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etapaCotizacion == null)
            {
                return NotFound();
            }

            return View(etapaCotizacion);
        }

        // POST: EtapaCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EtapaCotizacions == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.EtapaCotizacions'  is null.");
            }
            var etapaCotizacion = await _context.EtapaCotizacions.FindAsync(id);
            if (etapaCotizacion != null)
            {
                _context.EtapaCotizacions.Remove(etapaCotizacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtapaCotizacionExists(int id)
        {
          return _context.EtapaCotizacions.Any(e => e.Id == id);
        }
    }
}
