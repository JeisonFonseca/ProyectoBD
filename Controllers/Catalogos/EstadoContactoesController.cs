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
    public class EstadoContactoesController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public EstadoContactoesController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: EstadoContactoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.EstadoContactos.ToListAsync());
        }

        // GET: EstadoContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadoContactos == null)
            {
                return NotFound();
            }

            var estadoContacto = await _context.EstadoContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoContacto == null)
            {
                return NotFound();
            }

            return View(estadoContacto);
        }

        // GET: EstadoContactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EstadoContacto estadoContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoContacto);
        }

        // GET: EstadoContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadoContactos == null)
            {
                return NotFound();
            }

            var estadoContacto = await _context.EstadoContactos.FindAsync(id);
            if (estadoContacto == null)
            {
                return NotFound();
            }
            return View(estadoContacto);
        }

        // POST: EstadoContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EstadoContacto estadoContacto)
        {
            if (id != estadoContacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoContactoExists(estadoContacto.Id))
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
            return View(estadoContacto);
        }

        // GET: EstadoContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadoContactos == null)
            {
                return NotFound();
            }

            var estadoContacto = await _context.EstadoContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoContacto == null)
            {
                return NotFound();
            }

            return View(estadoContacto);
        }

        // POST: EstadoContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadoContactos == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.EstadoContactos'  is null.");
            }
            var estadoContacto = await _context.EstadoContactos.FindAsync(id);
            if (estadoContacto != null)
            {
                _context.EstadoContactos.Remove(estadoContacto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoContactoExists(int id)
        {
          return _context.EstadoContactos.Any(e => e.Id == id);
        }
    }
}
