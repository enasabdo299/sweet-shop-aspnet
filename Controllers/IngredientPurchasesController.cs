using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetShop.Data;
using SweetShop.Models;

namespace SweetShop.Controllers
{
    public class IngredientPurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientPurchasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IngredientPurchases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IngredientPurchases.Include(i => i.Ingredient).Include(i => i.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IngredientPurchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IngredientPurchases == null)
            {
                return NotFound();
            }

            var ingredientPurchase = await _context.IngredientPurchases
                .Include(i => i.Ingredient)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.PurchaseID == id);
            if (ingredientPurchase == null)
            {
                return NotFound();
            }

            return View(ingredientPurchase);
        }

        // GET: IngredientPurchases/Create
        public IActionResult Create()
        {
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID");
            return View();
        }

        // POST: IngredientPurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseID,SupplierID,IngredientID,PurchaseDate,Quantity")] IngredientPurchase ingredientPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredientPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", ingredientPurchase.IngredientID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", ingredientPurchase.SupplierID);
            return View(ingredientPurchase);
        }

        // GET: IngredientPurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IngredientPurchases == null)
            {
                return NotFound();
            }

            var ingredientPurchase = await _context.IngredientPurchases.FindAsync(id);
            if (ingredientPurchase == null)
            {
                return NotFound();
            }
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", ingredientPurchase.IngredientID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", ingredientPurchase.SupplierID);
            return View(ingredientPurchase);
        }

        // POST: IngredientPurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseID,SupplierID,IngredientID,PurchaseDate,Quantity")] IngredientPurchase ingredientPurchase)
        {
            if (id != ingredientPurchase.PurchaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredientPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientPurchaseExists(ingredientPurchase.PurchaseID))
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
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", ingredientPurchase.IngredientID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", ingredientPurchase.SupplierID);
            return View(ingredientPurchase);
        }

        // GET: IngredientPurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IngredientPurchases == null)
            {
                return NotFound();
            }

            var ingredientPurchase = await _context.IngredientPurchases
                .Include(i => i.Ingredient)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.PurchaseID == id);
            if (ingredientPurchase == null)
            {
                return NotFound();
            }

            return View(ingredientPurchase);
        }

        // POST: IngredientPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IngredientPurchases == null)
            {
                return Problem("Entity set 'ApplicationDbContext.IngredientPurchases'  is null.");
            }
            var ingredientPurchase = await _context.IngredientPurchases.FindAsync(id);
            if (ingredientPurchase != null)
            {
                _context.IngredientPurchases.Remove(ingredientPurchase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientPurchaseExists(int id)
        {
          return (_context.IngredientPurchases?.Any(e => e.PurchaseID == id)).GetValueOrDefault();
        }
    }
}
