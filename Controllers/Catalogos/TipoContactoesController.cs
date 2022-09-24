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
    public class TipoContactoesController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public TipoContactoesController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: TipoContactoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoContactos.ToListAsync());
        }

        // GET: TipoContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoContactos == null)
            {
                return NotFound();
            }

            var tipoContacto = await _context.TipoContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoContacto == null)
            {
                return NotFound();
            }

            return View(tipoContacto);
        }

        // GET: TipoContactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoContacto tipoContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContacto);
        }

        // GET: TipoContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoContactos == null)
            {
                return NotFound();
            }

            var tipoContacto = await _context.TipoContactos.FindAsync(id);
            if (tipoContacto == null)
            {
                return NotFound();
            }
            return View(tipoContacto);
        }

        // POST: TipoContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoContacto tipoContacto)
        {
            if (id != tipoContacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContactoExists(tipoContacto.Id))
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
            return View(tipoContacto);
        }

        // GET: TipoContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoContactos == null)
            {
                return NotFound();
            }

            var tipoContacto = await _context.TipoContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoContacto == null)
            {
                return NotFound();
            }

            return View(tipoContacto);
        }

        // POST: TipoContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoContactos == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.TipoContactos'  is null.");
            }
            var tipoContacto = await _context.TipoContactos.FindAsync(id);
            if (tipoContacto != null)
            {
                _context.TipoContactos.Remove(tipoContacto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContactoExists(int id)
        {
          return _context.TipoContactos.Any(e => e.Id == id);
        }
    }
}
