﻿using DevSpot.Constants;
using Microsoft.AspNetCore.Identity;

namespace DevSpot.Data
{
	public class UserSeeder
	{
		public static async Task SeedUserAsync(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

			await CreateUserWithRole(userManager, "admin@devspot.com", "Admin123!", Roles.Admin);
			await CreateUserWithRole(userManager, "jobseeker@devspot.com", "Jobseeker123!", Roles.JobSeeker);
			await CreateUserWithRole(userManager, "employer@devspot.com", "Employer123!", Roles.Employer);

		}

		public static async Task CreateUserWithRole(UserManager<IdentityUser>
			userManager, string email, string password, string role)
			// now the method is 100% dynamic 
		{
			if (await userManager.FindByEmailAsync(email) == null)
			{
				var user = new IdentityUser
				{
					Email = email,
					EmailConfirmed = true,
					UserName = email
				};

				var result = await userManager.CreateAsync(user, password);

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, role);
				}
				else
				{
					throw new Exception($"Failed creating user with email {user.Email}. Errors: " +
						$"{string.Join(",", result.Errors)}");
				}
			}
		}
	}
}
