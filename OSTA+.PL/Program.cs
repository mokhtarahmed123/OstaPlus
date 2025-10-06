using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSTA_.DAL.Database;
using OSTA_.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Register EF Core with your DbContext
builder.Services.AddDbContext<OstaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<OstaDbContext>()
    .AddDefaultTokenProviders();


// ✅ Add MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Enable authentication + authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
