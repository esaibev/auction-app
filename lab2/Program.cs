using lab2.Core;
using lab2.Core.Interfaces;
using lab2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using lab2.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();

// Add db context with dependency injection
builder.Services.AddDbContext<AuctionDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AuctionDbConnection")));

// Add configurations for Identity
builder.Services.AddDbContext<AuctionAppIdentityContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AuctionAppIdentityContextConnection")));
builder.Services.AddDefaultIdentity<AuctionAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuctionAppIdentityContext>();

// Add scanning of AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

