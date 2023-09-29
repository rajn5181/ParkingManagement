using AuthService.Models.Dto;
using AuthService.Models;
using Microsoft.AspNetCore.Identity;
using AuthService.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AuthService.Services.IServices
{
    public class AuthServices : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthServices(AppDbContext db, UserManager<AppUserModel> userManager, IJwtTokenGenerator jwtTokenGenerator,RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _dbContext = db;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
            _configuration = configuration;
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
                PhoneNumber = user.PhoneNumber,
                Role=user.Role,
              
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
                PhoneNumber = registration.PhoneNumber,
                Role=registration.Role,

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
        public async Task<UpdateProfileDto> UpdateProfile(string userEmail, UpdateProfileDto model)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
               
                return new UpdateProfileDto
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

           
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new UpdateProfileDto
                {
                    IsSuccess = true,
                    Message = "Profile updated successfully"
                };
            }
            else
            {
               
                return new UpdateProfileDto
                {
                    IsSuccess = false,
                    Message = "Profile update failed"
                };
            }
        }

        public async Task<AppUserModel> FindUserByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }
        // In AuthServices.cs

        public async Task<string> AdwinRegister(AdwinRegistrationDto registration)
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

        public async Task<LoginResponseDto> AdwinLogin(AdwinLoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
            {
                return new LoginResponseDto { User = null, Tokens = "" };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDto userDto = new UserDto
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Password = user.PasswordHash,
                Role=user.Role,

            };

            return new LoginResponseDto
            {
                User = userDto,
                Tokens = token
            };
        }
        public string GetPasswordHash(string username)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    using (var command = new SqlCommand("PMSGettingAdminPass", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserId", username));

                        var result = command.ExecuteScalar();

                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
              
                return null;
            }
        }




    }
}
