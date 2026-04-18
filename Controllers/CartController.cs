using Microsoft.AspNetCore.Mvc;
using SweetShop.Data;
using SweetShop.Models;
using System.Text.Json;

namespace SweetShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // إذا لم تكن السلة موجودة في الجلسة، أنشئ واحدة جديدة
            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson) ? new CartViewModel() : JsonSerializer.Deserialize<CartViewModel>(cartJson);

            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }

            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson) ? new CartViewModel() : JsonSerializer.Deserialize<CartViewModel>(cartJson);

            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem == null)
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    Price = product.Price ?? 0,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            cart.TotalPrice = cart.Items.Sum(i => i.Price * i.Quantity);

            // حفظ السلة في الجلسة
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));

            return RedirectToAction("Index");
        }
    }
}
