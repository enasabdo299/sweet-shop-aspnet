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
    public class ProductRecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductRecipes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductRecipes.Include(p => p.Ingredient).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductRecipes == null)
            {
                return NotFound();
            }

            var productRecipe = await _context.ProductRecipes
                .Include(p => p.Ingredient)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (productRecipe == null)
            {
                return NotFound();
            }

            return View(productRecipe);
        }

        // GET: ProductRecipes/Create
        public IActionResult Create()
        {
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return View();
        }

        // POST: ProductRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,ProductID,IngredientID,Quantity")] ProductRecipe productRecipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", productRecipe.IngredientID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", productRecipe.ProductID);
            return View(productRecipe);
        }

        // GET: ProductRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductRecipes == null)
            {
                return NotFound();
            }

            var productRecipe = await _context.ProductRecipes.FindAsync(id);
            if (productRecipe == null)
            {
                return NotFound();
            }
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", productRecipe.IngredientID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", productRecipe.ProductID);
            return View(productRecipe);
        }

        // POST: ProductRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,ProductID,IngredientID,Quantity")] ProductRecipe productRecipe)
        {
            if (id != productRecipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productRecipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductRecipeExists(productRecipe.RecipeID))
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
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", productRecipe.IngredientID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", productRecipe.ProductID);
            return View(productRecipe);
        }

        // GET: ProductRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductRecipes == null)
            {
                return NotFound();
            }

            var productRecipe = await _context.ProductRecipes
                .Include(p => p.Ingredient)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (productRecipe == null)
            {
                return NotFound();
            }

            return View(productRecipe);
        }

        // POST: ProductRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductRecipes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductRecipes'  is null.");
            }
            var productRecipe = await _context.ProductRecipes.FindAsync(id);
            if (productRecipe != null)
            {
                _context.ProductRecipes.Remove(productRecipe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductRecipeExists(int id)
        {
          return (_context.ProductRecipes?.Any(e => e.RecipeID == id)).GetValueOrDefault();
        }
    }
}
