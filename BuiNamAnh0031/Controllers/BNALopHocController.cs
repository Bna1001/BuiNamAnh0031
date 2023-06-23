using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuiNamAnh0031.Models;

namespace BuiNamAnh0031.Controllers
{
    public class BNALopHocController : Controller
    {
        private readonly SQLite _context;

        public BNALopHocController(SQLite context)
        {
            _context = context;
        }

        // GET: BNALopHoc
        public async Task<IActionResult> Index()
        {
              return _context.BNALopHoc != null ? 
                          View(await _context.BNALopHoc.ToListAsync()) :
                          Problem("Entity set 'SQLite.BNALopHoc'  is null.");
        }

        // GET: BNALopHoc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BNALopHoc == null)
            {
                return NotFound();
            }

            var bNALopHoc = await _context.BNALopHoc
                .FirstOrDefaultAsync(m => m.BNAMaLop == id);
            if (bNALopHoc == null)
            {
                return NotFound();
            }

            return View(bNALopHoc);
        }

        // GET: BNALopHoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BNALopHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BNAMaLop,BNATenLop")] BNALopHoc bNALopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bNALopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bNALopHoc);
        }

        // GET: BNALopHoc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BNALopHoc == null)
            {
                return NotFound();
            }

            var bNALopHoc = await _context.BNALopHoc.FindAsync(id);
            if (bNALopHoc == null)
            {
                return NotFound();
            }
            return View(bNALopHoc);
        }

        // POST: BNALopHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BNAMaLop,BNATenLop")] BNALopHoc bNALopHoc)
        {
            if (id != bNALopHoc.BNAMaLop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bNALopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BNALopHocExists(bNALopHoc.BNAMaLop))
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
            return View(bNALopHoc);
        }

        // GET: BNALopHoc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BNALopHoc == null)
            {
                return NotFound();
            }

            var bNALopHoc = await _context.BNALopHoc
                .FirstOrDefaultAsync(m => m.BNAMaLop == id);
            if (bNALopHoc == null)
            {
                return NotFound();
            }

            return View(bNALopHoc);
        }

        // POST: BNALopHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BNALopHoc == null)
            {
                return Problem("Entity set 'SQLite.BNALopHoc'  is null.");
            }
            var bNALopHoc = await _context.BNALopHoc.FindAsync(id);
            if (bNALopHoc != null)
            {
                _context.BNALopHoc.Remove(bNALopHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BNALopHocExists(string id)
        {
          return (_context.BNALopHoc?.Any(e => e.BNAMaLop == id)).GetValueOrDefault();
        }
    }
}
