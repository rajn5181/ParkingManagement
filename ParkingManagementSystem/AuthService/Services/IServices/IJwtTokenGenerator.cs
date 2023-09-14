using AuthService.Models;

namespace AuthService.Services.IServices
{
    public interface IJwtTokenGenerator
    {
      string GenerateToken(AppUserModel applicationUser);
    }
}
