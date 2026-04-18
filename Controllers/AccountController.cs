using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Models; // تأكد من وجود LoginViewModel في هذا المسار أو حدّثه حسب موقعه في مشروعك
using System.Threading.Tasks;

namespace SweetShop.Controllers
{
    public class AccountController : Controller
    {

        // عرض صفحة التسجيل
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // استقبال بيانات التسجيل والتحقق منها
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // قم هنا بإضافة الحساب إلى قاعدة البيانات، مثلًا بإضافة `Customer`
                // بعدها يمكن تحويل المستخدم إلى صفحة تسجيل الدخول
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (await _userManager.IsInRoleAsync( user ,"Admin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
