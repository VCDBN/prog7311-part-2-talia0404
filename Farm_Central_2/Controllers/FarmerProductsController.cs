using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farm_Central_2.Models;

namespace Farm_Central_2.Controllers
{
    public class FarmerProductsController : Controller
    {
        private readonly PROG_2023Context _context;

        public FarmerProductsController(PROG_2023Context context)
        {
            _context = context;
        }

        // GET: FarmerProducts
        public async Task<IActionResult> Index()
        {
            var pROG_2023Context = _context.FarmerProducts.Include(f => f.Farmer);
            return View(await pROG_2023Context.ToListAsync());
        }

        // GET: FarmerProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProducts = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (farmerProducts == null)
            {
                return NotFound();
            }

            return View(farmerProducts);
        }

        // GET: FarmerProducts/Create
        public IActionResult Create()
        {
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "FarmerId");
            return View();
        }

        // POST: FarmerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,FarmerId")] FarmerProducts farmerProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmerProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "FarmerId", farmerProducts.FarmerId);
            return View(farmerProducts);
        }

       


        // GET: FarmerProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProducts = await _context.FarmerProducts.FindAsync(id);
            if (farmerProducts == null)
            {
                return NotFound();
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "FarmerId", farmerProducts.FarmerId);
            return View(farmerProducts);
        }

        // POST: FarmerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,FarmerId")] FarmerProducts farmerProducts)
        {
            if (id != farmerProducts.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmerProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerProductsExists(farmerProducts.ProductId))
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
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "FarmerId", farmerProducts.FarmerId);
            return View(farmerProducts);
        }

        // GET: FarmerProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProducts = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (farmerProducts == null)
            {
                return NotFound();
            }

            return View(farmerProducts);
        }

        // POST: FarmerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmerProducts = await _context.FarmerProducts.FindAsync(id);
            _context.FarmerProducts.Remove(farmerProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerProductsExists(int id)
        {
            return _context.FarmerProducts.Any(e => e.ProductId == id);
        }
    }
}
