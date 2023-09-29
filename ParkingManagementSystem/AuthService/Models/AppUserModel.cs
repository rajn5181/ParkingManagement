using Microsoft.AspNetCore.Identity;

namespace AuthService.Models
{
    public class AppUserModel:IdentityUser
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
