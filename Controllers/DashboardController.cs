using Microsoft.AspNetCore.Mvc;
using SweetShop.Data;
using SweetShop.Models;
using System.Linq;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new DashboardViewModel
        {
            TotalCustomers = _context.Customers.Count(),
            TotalOrders = _context.Orders.Count(),
            TotalProducts = _context.Products.Count(),
            Employee = _context.Employees.Count(),
            Invoice = _context.Invoices.Count(),
            Inventory = _context.Inventories.Count(),
            OrderDetail = _context.OrderDetails.Count(),
            ProductRecipe = _context.ProductRecipes.Count(),
            Supplier = _context.Suppliers.Count(),
            Ingredients = _context.Ingredients.Count(),
            IngredientPurchases = _context.IngredientPurchases.Count()
        };

        return View(model);
    }
}
