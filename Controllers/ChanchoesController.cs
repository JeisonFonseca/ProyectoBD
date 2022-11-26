using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;


namespace Proyecto.Controllers
{
    public class ChanchoesController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public ChanchoesController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        // GET: Chanchoes
        public async Task<IActionResult> Index()
        {

            return View();
            //return View(await _context.VistaPorcinosGenerals.ToListAsync());
        }

        // GET: Chanchoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chanchos == null)
            {
                return NotFound();
            }

            var chancho = await _context.Chanchos
                .Include(c => c.SexoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chancho == null)
            {
                return NotFound();
            }

            return View(chancho);
        }

        // GET: Chanchoes/Create
        public IActionResult Create()
        {
            List<Sexo> lstSexo = new List<Sexo>();
            lstSexo = (from c in _context.Sexos select new Sexo { Identificador = c.Identificador, Nombre = c.Nombre }).ToList();
            lstSexo.Insert(0, new Sexo { Identificador = 0, Nombre = "Seleccione el sexo" });
            ViewBag.messageSexo = lstSexo;

            List<Encargado> lstDueno = new List<Encargado>();
            lstDueno = (from c in _context.Encargados select new Encargado { Cedula = c.Cedula, Nombre = c.Nombre }).ToList();
            lstDueno.Insert(0, new Encargado { Cedula = "", Nombre = "Seleccione el dueño" });
            ViewBag.messageDueno = lstDueno;

            return View();
        }

        // POST: Chanchoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaLlegada,PesoLlegada,FechaSalida,PesoSalida,Sexo")] Chancho chancho)
        {
            if (ModelState.IsValid)
            {
                var porcino = new Chancho()
                {
                    Id = chancho.Id,
                    Nombre = chancho.Nombre,
                    FechaLlegada = chancho.FechaLlegada,
                    PesoLlegada = chancho.PesoLlegada,
                    FechaSalida = chancho.FechaSalida,
                    PesoSalida = chancho.PesoSalida,
                    Sexo = chancho.Sexo
                };

                var EC = new EncargadoChancho()
                {
                   // CedulaEncargado = chancho.Dueno,
                   // IdentificadorChancho = chancho.Id
                };

                _context.Add(chancho);
                _context.Add(EC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }            
            return View(chancho);
        }

        // GET: Chanchoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chanchos == null)
            {
                return NotFound();
            }

            var chancho = await _context.Chanchos.FindAsync(id);
            if (chancho == null)
            {
                return NotFound();
            }
            ViewData["Sexo"] = new SelectList(_context.Sexos, "Identificador", "Identificador", chancho.Sexo);
            return View(chancho);
        }

        // POST: Chanchoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaLlegada,PesoLlegada,FechaSalida,PesoSalida,Sexo")] Chancho chancho)
        {
            if (id != chancho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chancho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChanchoExists(chancho.Id))
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
            ViewData["Sexo"] = new SelectList(_context.Sexos, "Identificador", "Identificador", chancho.Sexo);
            return View(chancho);
        }

        // GET: Chanchoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chanchos == null)
            {
                return NotFound();
            }

            var chancho = await _context.Chanchos
                .Include(c => c.SexoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chancho == null)
            {
                return NotFound();
            }

            return View(chancho);
        }

        // POST: Chanchoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chanchos == null)
            {
                return Problem("Entity set 'FincaLosLaurelesContext.Chanchos'  is null.");
            }
            var chancho = await _context.Chanchos.FindAsync(id);
            if (chancho != null)
            {
                _context.Chanchos.Remove(chancho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChanchoExists(int id)
        {
          return _context.Chanchos.Any(e => e.Id == id);
        }
    }
}
