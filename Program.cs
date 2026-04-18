using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetShop.Controllers;
using SweetShop.Data;

var builder = WebApplication.CreateBuilder(args);



// تكوين قاعدة البيانات (استبدل `YourDbContext` بقاعدة بياناتك الخاصة)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession();  // تفعيل الجلسات


// تكوين خدمات الهوية
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// تكوين خدمات MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// تكوين المصفوفة الخاصة بطلبات HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();  // تأكد من تفعيل الجلسات


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


