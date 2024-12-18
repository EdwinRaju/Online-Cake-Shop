using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BethanysPieShopContext")
    ?? throw new InvalidOperationException("Connection string 'BethanysPieShopContext' not found.");

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<BethanysPieShopContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopContext"]
        );
});

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<BethanysPieShopContext>();

builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var app = builder.Build();


app.UseStaticFiles();
app.UseSession();

if( app.Environment.IsDevelopment() )
{

app.UseDeveloperExceptionPage();

}

app.MapDefaultControllerRoute();

//app.MapControllerRoute(
//  name:"Default",
//pattern : "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();

DbInitializer.Seed(app);

app.Run();
