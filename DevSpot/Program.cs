using DevSpot.Constants;
using DevSpot.Data;
using DevSpot.Interfaces;
using DevSpot.Models;
using DevSpot.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(
	options => options.SignIn.RequireConfirmedAccount = false) 
	.AddRoles<IdentityRole>() 
	.AddEntityFrameworkStores<ApplicationDbContext>(); 

builder.Services.AddScoped<IRepository<JobPosting>, JobPostingRepository>();




builder.Services.AddControllersWithViews(); 

var app = builder.Build();



if (!app.Environment.IsDevelopment()) 
{
	
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts(); 
}

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	RoleSeeder.SeedRolesAsync(services).Wait();	
	UserSeeder.SeedUserAsync(services).Wait();
}


app.UseHttpsRedirection(); 


app.UseStaticFiles(); 


app.UseRouting(); 


app.UseAuthorization(); 


app.MapRazorPages(); 


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run(); 




