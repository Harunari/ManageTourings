using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manage_Tourings.Models;
using Manage_Tourings.Models.Touring;

namespace Manage_Tourings.Controllers
{
    public class TouringsController : Controller
    {
        private readonly ManageTouringsContext _context;

        public TouringsController(ManageTouringsContext context)
        {
            _context = context;
        }

        // GET: Tourings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tourings.ToListAsync());
        }

        // GET: Tourings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touring = await _context.Tourings
                .FirstOrDefaultAsync(m => m.TouringId == id);
            if (touring == null)
            {
                return NotFound();
            }

            return View(touring);
        }

        // GET: Tourings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tourings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Note")] Touring touring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(touring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(touring);
        }

        // GET: Tourings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touring = await _context.Tourings.FindAsync(id);
            if (touring == null)
            {
                return NotFound();
            }
            return View(touring);
        }

        // POST: Tourings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Note")] Touring touring)
        {
            if (id != touring.TouringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouringExists(touring.TouringId))
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
            return View(touring);
        }

        // GET: Tourings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touring = await _context.Tourings
                .FirstOrDefaultAsync(m => m.TouringId == id);
            if (touring == null)
            {
                return NotFound();
            }

            return View(touring);
        }

        // POST: Tourings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var touring = await _context.Tourings.FindAsync(id);
            _context.Tourings.Remove(touring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouringExists(int id)
        {
            return _context.Tourings.Any(e => e.TouringId == id);
        }
    }
}
