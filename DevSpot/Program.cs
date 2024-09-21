using DevSpot.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(
	options => options.SignIn.RequireConfirmedAccount = false) 
	.AddRoles<IdentityRole>() 
	.AddEntityFrameworkStores<ApplicationDbContext>(); 

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
	var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();	

	if (!roleManager.RoleExistsAsync("Admin").Result)
	{
		var result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;
	}
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




