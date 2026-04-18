using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // الأدوار المطلوبة
        string[] roles = { "Admin", "Customer" };

        // إنشاء الأدوار إذا لم تكن موجودة
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // إنشاء حساب المسؤول إذا لم يكن موجودًا
        var adminUserEmail = "admin@sweetshop.com";
        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminUserEmail,
                Email = adminUserEmail
            };

            var createAdminResult = await userManager.CreateAsync(adminUser, "AdminPassword123!");
            if (createAdminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                // تسجيل الأخطاء إذا فشل إنشاء المستخدم الإداري
                Console.WriteLine("فشل إنشاء مستخدم المسؤول");
                foreach (var error in createAdminResult.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }
        }

        // إنشاء حساب افتراضي لعميل إذا لم يكن موجودًا
        var customerUserEmail = "customer@sweetshop.com";
        var customerUser = await userManager.FindByEmailAsync(customerUserEmail);
        if (customerUser == null)
        {
            customerUser = new IdentityUser
            {
                UserName = customerUserEmail,
                Email = customerUserEmail
            };

            var createCustomerResult = await userManager.CreateAsync(customerUser, "CustomerPassword123!");
            if (createCustomerResult.Succeeded)
            {
                await userManager.AddToRoleAsync(customerUser, "Customer");
            }
            else
            {
                // تسجيل الأخطاء إذا فشل إنشاء المستخدم العميل
                Console.WriteLine("فشل إنشاء مستخدم العميل");
                foreach (var error in createCustomerResult.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }
        }
    }
}
