using ExamenSelvinMedina.Infrastucture.Universidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenSelvinMedina.Controllers
{
    public class MaestroExamenController : Controller
    {
        private readonly UniversidadDbContext _context;

        public MaestroExamenController(UniversidadDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.MaestroExamen.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MaestroExamen == null)
            {
                return NotFound();
            }

            var maestroExamen = await _context.MaestroExamen
                .FirstOrDefaultAsync(m => m.Ncuenta == id);
            if (maestroExamen == null)
            {
                return NotFound();
            }

            return View(maestroExamen);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ncuenta,NombreCompleto,Profesion,Carrera,Edad")] MaestroExamen maestroExamen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maestroExamen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MaestroExamen == null)
            {
                return NotFound();
            }

            var maestroExamen = await _context.MaestroExamen.FindAsync(id);
            if (maestroExamen == null)
            {
                return NotFound();
            }
            return View(maestroExamen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ncuenta,NombreCompleto,Profesion,Carrera,Edad")] MaestroExamen maestroExamen)
        {
            if (id != maestroExamen.Ncuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maestroExamen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaestroExamenExists(maestroExamen.Ncuenta))
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
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MaestroExamen == null)
            {
                return NotFound();
            }

            var maestroExamen = await _context.MaestroExamen
                .FirstOrDefaultAsync(m => m.Ncuenta == id);
            if (maestroExamen == null)
            {
                return NotFound();
            }

            return View(maestroExamen);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MaestroExamen == null)
            {
                return Problem("Entity set 'UniversidadDbContext.MaestroExamen'  is null.");
            }
            var maestroExamen = await _context.MaestroExamen.FindAsync(id);
            if (maestroExamen != null)
            {
                _context.MaestroExamen.Remove(maestroExamen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaestroExamenExists(int id)
        {
            return _context.MaestroExamen.Any(e => e.Ncuenta == id);
        }
    }
}
