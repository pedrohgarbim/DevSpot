﻿using Microsoft.AspNetCore.Identity;

namespace DevSpot.Data
{
	public class UserSeeder
	{
		public static async Task SeedUserAsync(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
		}
	}
}
