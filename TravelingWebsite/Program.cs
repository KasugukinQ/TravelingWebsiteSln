using Microsoft.EntityFrameworkCore;
using TravelingWebsite.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDBContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:TravelingWebsiteConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Booking>(sp => SessionBooking.GetBooking(sp));
builder.Services.AddSingleton<IHttpContextAccessor,
    HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("catpage",
    "{category}/Page{packagePage:int}",
    new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page", "Page{packagePage:int}",
    new { Controller = "Home", action = "Index", packagePage = 1 });

app.MapControllerRoute("category", "{category}",
    new { Controller = "Home", action = "Index", packagePage = 1 });

app.MapControllerRoute("pagination",
    "Packages/Page{packagePage}",
    new { Controller = "Home", action = "Index", packagePage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

SeedData.EnsurePopulated(app);

app.Run();
