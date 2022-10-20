using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class BovinoController : Controller
    {
        private readonly FincaLosLaurelesContext _context;

        public BovinoController(FincaLosLaurelesContext context)
        {
            _context = context;
        }

        // GET: Bovino
        public async Task<IActionResult> Index()
        {
            return View(await _context.VistaBovinos.ToListAsync());
        }

        // GET: Bovino/Create
        public IActionResult Create()
        {
            List<Raza> lstRazas = new List<Raza>();
            lstRazas = (from c in _context.Razas select new Raza { Identificador = c.Identificador, Nombre = c.Nombre }).ToList();
            lstRazas.Insert(0, new Raza { Identificador = 0, Nombre = "Seleccione la raza del animal" });
            ViewBag.messageRazas = lstRazas;

            List<Bovino> lstBovinos = new List<Bovino>();
            lstBovinos = (from c in _context.Bovinos select new Bovino { Identificador = c.Identificador, Nombre = c.Nombre }).ToList();
            lstBovinos.Insert(0, new Bovino { Identificador = 0, Nombre = "Seleccione la madre" });
            ViewBag.messageMadre = lstBovinos;

            List<Bovino> lstBovinos2 = new List<Bovino>();
            lstBovinos2 = (from c in _context.Bovinos select new Bovino { Identificador = c.Identificador, Nombre = c.Nombre }).ToList();
            lstBovinos2.Insert(0, new Bovino { Identificador = 0, Nombre = "Seleccione el padre" });
            ViewBag.messagePadre = lstBovinos2;

            List<Adquisión> lstAdquision = new List<Adquisión>();
            lstAdquision = (from c in _context.Adquisións select new Adquisión { Identificador = c.Identificador, Nombre = c.Nombre }).ToList();
            lstAdquision.Insert(0, new Adquisión { Identificador = 0, Nombre = "Seleccione la forma de adquisición" });
            ViewBag.messageAdquisicion = lstAdquision;

            List<Sexo> lstSexo = new List<Sexo>();
            lstSexo = (from c in _context.Sexos select new Sexo { Identificador = c.Identificador, Nombre = c.Nombre }).ToList();
            lstSexo.Insert(0, new Sexo { Identificador = 0, Nombre = "Seleccione el sexo" });
            ViewBag.messageSexo = lstSexo;

            return View();
        }

        // POST: Bovino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Nombre")] Adquisión adquisión)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adquisión);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            return View(adquisión);
        }
    }
}
