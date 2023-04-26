using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP2.Data;
using TP2.Models;

namespace TP2.Controllers
{
    public class HeladeriaController : Controller
    {
        private readonly MvcHeladeriaContext _context;

        public HeladeriaController(MvcHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Heladeria
        public async Task<IActionResult> Index()
        {
            var mvcHeladeriaContext = _context.Heladeria.Include(h => h.Direccion);
            return View(await mvcHeladeriaContext.ToListAsync());
        }

        // GET: Heladeria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Heladeria == null)
            {
                return NotFound();
            }

            var heladeria = await _context.Heladeria
                .Include(h => h.Direccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heladeria == null)
            {
                return NotFound();
            }

            return View(heladeria);
        }

        // GET: Heladeria/Create
        public IActionResult Create()
        {
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Id");
            return View();
        }

        // POST: Heladeria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Marca,DireccionId")] Heladeria heladeria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heladeria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Id", heladeria.DireccionId);
            return View(heladeria);
        }

        // GET: Heladeria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Heladeria == null)
            {
                return NotFound();
            }

            var heladeria = await _context.Heladeria.FindAsync(id);
            if (heladeria == null)
            {
                return NotFound();
            }
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Id", heladeria.DireccionId);
            return View(heladeria);
        }

        // POST: Heladeria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Marca,DireccionId")] Heladeria heladeria)
        {
            if (id != heladeria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heladeria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeladeriaExists(heladeria.Id))
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
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Id", heladeria.DireccionId);
            return View(heladeria);
        }

        // GET: Heladeria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Heladeria == null)
            {
                return NotFound();
            }

            var heladeria = await _context.Heladeria
                .Include(h => h.Direccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heladeria == null)
            {
                return NotFound();
            }

            return View(heladeria);
        }

        // POST: Heladeria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Heladeria == null)
            {
                return Problem("Entity set 'MvcHeladeriaContext.Heladeria'  is null.");
            }
            var heladeria = await _context.Heladeria.FindAsync(id);
            if (heladeria != null)
            {
                _context.Heladeria.Remove(heladeria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeladeriaExists(int id)
        {
          return (_context.Heladeria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
