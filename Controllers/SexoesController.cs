﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class SexoesController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public SexoesController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        // GET: Sexoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sexos.ToListAsync());
        }

        // GET: Sexoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sexos == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexos
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // GET: Sexoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Nombre")] Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sexo);
        }

        // GET: Sexoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sexos == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexos.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }
            return View(sexo);
        }

        // POST: Sexoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Nombre")] Sexo sexo)
        {
            if (id != sexo.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexoExists(sexo.Identificador))
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
            return View(sexo);
        }

        // GET: Sexoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sexos == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexos
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // POST: Sexoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sexos == null)
            {
                return Problem("Entity set 'FincaLosLaurelesContext.Sexos'  is null.");
            }
            var sexo = await _context.Sexos.FindAsync(id);
            if (sexo != null)
            {
                _context.Sexos.Remove(sexo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexoExists(int id)
        {
          return _context.Sexos.Any(e => e.Identificador == id);
        }
    }
}
