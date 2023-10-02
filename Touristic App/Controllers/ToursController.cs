using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Touristic_App.Models;

namespace Touristic_App.Controllers
{
    public class ToursController : Controller
    {
        private readonly UserContext _context;

        public ToursController(UserContext context)
        {
            _context = context;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
              return _context.TourVM != null ? 
                          View(await _context.TourVM.ToListAsync()) :
                          Problem("Entity set 'GuideContext.TourVM'  is null.");
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TourVM == null)
            {
                return NotFound();
            }

            var tourVM = await _context.TourVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourVM == null)
            {
                return NotFound();
            }

            return View(tourVM);
        }

        // GET: Tours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,NumberOfGuests")] Tour tourVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tourVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tourVM);
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TourVM == null)
            {
                return NotFound();
            }

            var tourVM = await _context.TourVM.FindAsync(id);
            if (tourVM == null)
            {
                return NotFound();
            }
            return View(tourVM);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,NumberOfGuests")] Tour tourVM)
        {
            if (id != tourVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourVMExists(tourVM.Id))
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
            return View(tourVM);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TourVM == null)
            {
                return NotFound();
            }

            var tourVM = await _context.TourVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourVM == null)
            {
                return NotFound();
            }

            return View(tourVM);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TourVM == null)
            {
                return Problem("Entity set 'GuideContext.TourVM'  is null.");
            }
            var tourVM = await _context.TourVM.FindAsync(id);
            if (tourVM != null)
            {
                _context.TourVM.Remove(tourVM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourVMExists(int id)
        {
          return (_context.TourVM?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
