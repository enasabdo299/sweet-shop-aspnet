using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetShop.Data;
using SweetShop.Models;
using System.Diagnostics;
 

namespace SweetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        // Constructor injection for logging and database context
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Index action: Displays a list of products
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Privacy page action
        public IActionResult Privacy()
        {
            return View();
        }

        // Error page action with caching disabled
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Login page action - Only an example if you want to add Login functionality
        public IActionResult Login()
        {
            return View(); // Create a view to display the login form
        }

        // Handle Login form submission
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Add your login logic here
                // For example, authenticate the user and redirect to a secure page
            }
            return View(model); // return the view with validation errors if any
        }
    }
}
