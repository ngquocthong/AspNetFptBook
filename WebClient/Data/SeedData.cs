using Microsoft.AspNetCore.Identity;

namespace WebClient.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            // Tạo roles mới
            var adminRole = new IdentityRole { Name = "Admin" };
            await roleManager.CreateAsync(adminRole);

            // Tạo users mới
            var user = new ApplicationUser { FullName = "Nguyen Quoc Thong", Email = "admin1@example.com", DofB= new DateTime(2022, 01, 02), Address="Phong Dien"};
            var result = await userManager.CreateAsync(user, "Admin@123");

            // Gán role cho user
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
