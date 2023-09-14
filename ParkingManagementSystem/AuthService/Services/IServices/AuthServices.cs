using AuthService.Models.Dto;
using AuthService.Models;
using Microsoft.AspNetCore.Identity;
using AuthService.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Services.IServices
{
    public class AuthServices : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthServices(AppDbContext db, UserManager<AppUserModel> userManager, IJwtTokenGenerator jwtTokenGenerator,RoleManager<IdentityRole> roleManager)
        {
            _dbContext = db;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        public async Task<bool> AssigRole(string email, string roleName)
        {
            var user = _dbContext.ApplicationUser.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if(user != null) 
            {
                if (_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult()) ;
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();

                }
                await _userManager.CreateAsync(user,roleName);
                return true;

            }
            return false;
        }
         
        public async Task<LoginResponseDto> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
            {
                return new LoginResponseDto { User = null, Tokens = "" };
            }
            var tocken=_jwtTokenGenerator.GenerateToken(user);
            UserDto userDto = new UserDto
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto
            {
                User = userDto,
                Tokens = tocken
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationDto registration)
        {
            var user = new AppUserModel
            {
                UserName = registration.Email,
                Email = registration.Email,
                NormalizedEmail = registration.Email.ToUpper(),
                Name = registration.Name,
                PhoneNumber = registration.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registration.Password);

                if (result.Succeeded)
                {
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault()?.Description ?? "Unknown registration error";
                }
            }
            catch (Exception ex)
            {
                return "Error encountered during registration";
            }
        }
    }
}
