using Microsoft.AspNetCore.Identity;

namespace WebClient.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public DateTime DofB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
