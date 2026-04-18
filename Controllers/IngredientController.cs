using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetShop.Data;
using SweetShop.Models;

public class IngredientsController : Controller
{
    private readonly ApplicationDbContext _context;

    public IngredientsController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: Ingredient/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Ingredient/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Ingredient ingredient)
    {
        if (ModelState.IsValid)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(ingredient);
    }
    // GET: Ingredient/Details/5
    public IActionResult Details(int id)
    {
        var ingredient = _context.Ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return View(ingredient);
    }

    // GET: Ingredient/Edit/5
    public IActionResult Edit(int id)
    {
        var ingredient = _context.Ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return View(ingredient);
    }

    // POST: Ingredient/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Ingredient ingredient)
    {
        if (id != ingredient.IngredientID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ingredient);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ingredients.Any(i => i.IngredientID == id))
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
        return View(ingredient);
    }


    // GET: Ingredient/Delete/5
    public IActionResult Delete(int id)
    {
        var ingredient = _context.Ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return View(ingredient);
    }
    public IActionResult Index()
    {
        var ingredients = _context.Ingredients.ToList();
        return View(ingredients);
    }
    
    // POST: Ingredient/DeleteConfirmed/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var ingredient = _context.Ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient != null)
        {
            _context.Ingredients.Remove(ingredient); // إزالة العنصر من الـ DbContext
            _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
        }
        return RedirectToAction(nameof(Index)); // إعادة التوجيه إلى صفحة الـ Index بعد الحذف
    }

}
