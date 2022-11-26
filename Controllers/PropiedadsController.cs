using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.Models.ViewModels;



namespace Proyecto.Controllers
{
    public class PropiedadsController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public PropiedadsController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        // GET: Propiedads
        public async Task<IActionResult> Index()
        {
              return View(await _context.VistaPropiedadDuenos.ToListAsync());
        }

        // GET: Propiedads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Propiedads == null)
            {
                return NotFound();
            }

            var propiedad = await _context.VistaPropiedadDuenos
                .FirstOrDefaultAsync(m => m.CodigoEscritura == id);
            if (propiedad == null)
            {
                return NotFound();
            }

            return View(propiedad);
        }

        // GET: Propiedads/Create
        public IActionResult Create()
        {
            List<Encargado> lstDueno = new List<Encargado>();
            lstDueno = (from c in _context.Encargados select new Encargado { Cedula = c.Cedula, Nombre = c.Nombre }).ToList();
            lstDueno.Insert(0, new Encargado { Cedula = "", Nombre = "Seleccione el dueño" });
            ViewBag.messageDueno = lstDueno;

            return View();
        }

        // POST: Propiedads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEscritura,Descripcion,Area,FechaCompra,Dueno")] PropiedadViewModel propiedad)
        {
            if (ModelState.IsValid)
            {
                var Propiedad = new Propiedad()
                {
                    CodigoEscritura = propiedad.CodigoEscritura,
                    Descripcion = propiedad.Descripcion,
                    Area = propiedad.Area,
                    FechaCompra = propiedad.FechaCompra,
                };

                var duenoPropiedad = new EncargadoPropiedad()
                {
                    CodigoPropiedad = propiedad.CodigoEscritura,
                    CedulaEncargado = propiedad.Dueno
                };
                _context.Add(Propiedad);
                _context.Add(duenoPropiedad); 
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propiedad);
        }

        // GET: Propiedads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Propiedads == null)
            {
                return NotFound();
            }

            var propiedad = await _context.Propiedads.FindAsync(id);
            if (propiedad == null)
            {
                return NotFound();
            }
            return View(propiedad);
        }

        // POST: Propiedads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEscritura,Descripcion,Area,FechaCompra")] Propiedad propiedad)
        {
            if (id != propiedad.CodigoEscritura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propiedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropiedadExists(propiedad.CodigoEscritura))
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
            return View(propiedad);
        }

        // GET: Propiedads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Propiedads == null)
            {
                return NotFound();
            }

            var propiedad = await _context.Propiedads
                .FirstOrDefaultAsync(m => m.CodigoEscritura == id);
            if (propiedad == null)
            {
                return NotFound();
            }

            return View(propiedad);
        }

        // POST: Propiedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Propiedads == null)
            {
                return Problem("Entity set 'FincaLosLaurelesContext.Propiedads'  is null.");
            }
            var propiedad = await _context.Propiedads.FindAsync(id);
            if (propiedad != null)
            {
                _context.Propiedads.Remove(propiedad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropiedadExists(int id)
        {
          return _context.Propiedads.Any(e => e.CodigoEscritura == id);
        }
    }
}
