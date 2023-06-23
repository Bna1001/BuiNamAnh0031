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
    public class BNASinhVienController : Controller
    {
        private readonly SQLite _context;

        public BNASinhVienController(SQLite context)
        {
            _context = context;
        }

        // GET: BNASinhVien
        public async Task<IActionResult> Index()
        {
            var sQLite = _context.BNASinhVien.Include(b => b.BNALopHoc);
            return View(await sQLite.ToListAsync());
        }

        // GET: BNASinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BNASinhVien == null)
            {
                return NotFound();
            }

            var bNASinhVien = await _context.BNASinhVien
                .Include(b => b.BNALopHoc)
                .FirstOrDefaultAsync(m => m.BNASinhVienMaSinhVien == id);
            if (bNASinhVien == null)
            {
                return NotFound();
            }

            return View(bNASinhVien);
        }

        // GET: BNASinhVien/Create
        public IActionResult Create()
        {
            ViewData["BNAMaLop"] = new SelectList(_context.BNALopHoc, "BNAMaLop", "BNAMaLop");
            return View();
        }

        // POST: BNASinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BNASinhVienMaSinhVien,BNAHoTen,BNAMaLop")] BNASinhVien bNASinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bNASinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BNAMaLop"] = new SelectList(_context.BNALopHoc, "BNAMaLop", "BNAMaLop", bNASinhVien.BNAMaLop);
            return View(bNASinhVien);
        }

        // GET: BNASinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BNASinhVien == null)
            {
                return NotFound();
            }

            var bNASinhVien = await _context.BNASinhVien.FindAsync(id);
            if (bNASinhVien == null)
            {
                return NotFound();
            }
            ViewData["BNAMaLop"] = new SelectList(_context.BNALopHoc, "BNAMaLop", "BNAMaLop", bNASinhVien.BNAMaLop);
            return View(bNASinhVien);
        }

        // POST: BNASinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BNASinhVienMaSinhVien,BNAHoTen,BNAMaLop")] BNASinhVien bNASinhVien)
        {
            if (id != bNASinhVien.BNASinhVienMaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bNASinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BNASinhVienExists(bNASinhVien.BNASinhVienMaSinhVien))
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
            ViewData["BNAMaLop"] = new SelectList(_context.BNALopHoc, "BNAMaLop", "BNAMaLop", bNASinhVien.BNAMaLop);
            return View(bNASinhVien);
        }

        // GET: BNASinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BNASinhVien == null)
            {
                return NotFound();
            }

            var bNASinhVien = await _context.BNASinhVien
                .Include(b => b.BNALopHoc)
                .FirstOrDefaultAsync(m => m.BNASinhVienMaSinhVien == id);
            if (bNASinhVien == null)
            {
                return NotFound();
            }

            return View(bNASinhVien);
        }

        // POST: BNASinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BNASinhVien == null)
            {
                return Problem("Entity set 'SQLite.BNASinhVien'  is null.");
            }
            var bNASinhVien = await _context.BNASinhVien.FindAsync(id);
            if (bNASinhVien != null)
            {
                _context.BNASinhVien.Remove(bNASinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BNASinhVienExists(string id)
        {
          return (_context.BNASinhVien?.Any(e => e.BNASinhVienMaSinhVien == id)).GetValueOrDefault();
        }
    }
}
