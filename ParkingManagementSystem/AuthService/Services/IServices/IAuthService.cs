using AuthService.Models;
using AuthService.Models.Dto;
using System.Threading.Tasks;

namespace AuthService.Services.IServices
{
    public interface IAuthService
    {
        Task<UpdateProfileDto> UpdateProfile(string userEmail, UpdateProfileDto model);
        Task<string> Register(RegistrationDto registrations);
        Task<LoginResponseDto> Login(LoginDto login);
        Task<bool> AssigRole(string email, string roleName);
        Task<AppUserModel> FindUserByUsernameAsync(string username);
    }
}
