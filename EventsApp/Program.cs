
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EventsApp.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var eventConnection = builder.Configuration.GetConnectionString("EventConnection");
var identityConnection = builder.Configuration.GetConnectionString("IdentityConnection");
// Add services to the container.
builder.Services.AddDbContext<EventsAppDBContext>(opts =>
                opts.UseSqlServer(eventConnection));
builder.Services.AddDbContext<IdentityContext>(opts =>
                opts.UseSqlServer(identityConnection));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.Configure<IdentityOptions>(opts => {
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
    opts.User.RequireUniqueEmail = true;
    //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
});
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/{0}.cshtml");
    });
;
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEventRepository,EFEventRepository>();
builder.Services.AddScoped<IPlayerRepository, EFPlayerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapControllerRoute("catpage",
        "{category}/Page{eventsPage:int}",
        new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{eventsPage:int}",
        new { Controller = "Home", action = "Index", eventsPage = 1 });
app.MapControllerRoute("category", "{category}",
        new { Controller = "Home", action = "Index", eventsPage = 1 });
app.MapControllerRoute("pagination",
        "Events/Page{eventsPage}",
        new { Controller = "Home", action = "Index", eventsPage = 1 });

SeedData.EnsurePopulated(app);

app.Run();
