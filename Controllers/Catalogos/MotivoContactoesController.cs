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
    public class MotivoContactoesController : Controller
    {
        private readonly PruebaProyecto1Context _context;

        public MotivoContactoesController(PruebaProyecto1Context context)
        {
            _context = context;
        }

        // GET: MotivoContactoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.MotivoContactos.ToListAsync());
        }

        // GET: MotivoContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MotivoContactos == null)
            {
                return NotFound();
            }

            var motivoContacto = await _context.MotivoContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivoContacto == null)
            {
                return NotFound();
            }

            return View(motivoContacto);
        }

        // GET: MotivoContactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotivoContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] MotivoContacto motivoContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motivoContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motivoContacto);
        }

        // GET: MotivoContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MotivoContactos == null)
            {
                return NotFound();
            }

            var motivoContacto = await _context.MotivoContactos.FindAsync(id);
            if (motivoContacto == null)
            {
                return NotFound();
            }
            return View(motivoContacto);
        }

        // POST: MotivoContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] MotivoContacto motivoContacto)
        {
            if (id != motivoContacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motivoContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotivoContactoExists(motivoContacto.Id))
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
            return View(motivoContacto);
        }

        // GET: MotivoContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MotivoContactos == null)
            {
                return NotFound();
            }

            var motivoContacto = await _context.MotivoContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivoContacto == null)
            {
                return NotFound();
            }

            return View(motivoContacto);
        }

        // POST: MotivoContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MotivoContactos == null)
            {
                return Problem("Entity set 'PruebaProyecto1Context.MotivoContactos'  is null.");
            }
            var motivoContacto = await _context.MotivoContactos.FindAsync(id);
            if (motivoContacto != null)
            {
                _context.MotivoContactos.Remove(motivoContacto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotivoContactoExists(int id)
        {
          return _context.MotivoContactos.Any(e => e.Id == id);
        }
    }
}
