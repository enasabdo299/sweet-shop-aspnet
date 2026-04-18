using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetShop.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using SweetShop.Data;

namespace SweetShop.Controllers
{
    public class ProductCustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductCustomer
        public async Task<IActionResult> Index()
        {
            // Fetch all products from the database
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: ProductCustomer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the product by ID
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
