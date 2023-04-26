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
    public class HeladoController : Controller
    {
        private readonly MvcHeladeriaContext _context;

        public HeladoController(MvcHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Helado
        public async Task<IActionResult> Index()
        {
              return _context.Helado != null ? 
                          View(await _context.Helado.ToListAsync()) :
                          Problem("Entity set 'MvcHeladeriaContext.Helado'  is null.");
        }

        // GET: Helado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Helado == null)
            {
                return NotFound();
            }

            var helado = await _context.Helado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helado == null)
            {
                return NotFound();
            }

            return View(helado);
        }

        // GET: Helado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Sabor")] Helado helado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(helado);
        }

        // GET: Helado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Helado == null)
            {
                return NotFound();
            }

            var helado = await _context.Helado.FindAsync(id);
            if (helado == null)
            {
                return NotFound();
            }
            return View(helado);
        }

        // POST: Helado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Sabor")] Helado helado)
        {
            if (id != helado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeladoExists(helado.Id))
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
            return View(helado);
        }

        // GET: Helado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Helado == null)
            {
                return NotFound();
            }

            var helado = await _context.Helado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helado == null)
            {
                return NotFound();
            }

            return View(helado);
        }

        // POST: Helado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Helado == null)
            {
                return Problem("Entity set 'MvcHeladeriaContext.Helado'  is null.");
            }
            var helado = await _context.Helado.FindAsync(id);
            if (helado != null)
            {
                _context.Helado.Remove(helado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeladoExists(int id)
        {
          return (_context.Helado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
