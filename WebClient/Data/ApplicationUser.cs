using Microsoft.AspNetCore.Identity;

namespace WebClient.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
    }
}
