using AuthService.Models.Dto;
using System.Threading.Tasks;

namespace AuthService.Services.IServices
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationDto registrations);
        Task<LoginResponseDto> Login(LoginDto login);
        Task<bool> AssigRole(string email, string roleName);
    }
}
