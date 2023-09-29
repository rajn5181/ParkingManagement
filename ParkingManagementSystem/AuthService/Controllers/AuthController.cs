using AuthService.Models.Dto;
using AuthService.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using AuthService.Models;

namespace AuthService.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _responseDto;
        private readonly UserManager<AppUserModel> _userManager;

        public AuthController(IAuthService authService, UserManager<AppUserModel> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto model)
        {
            try
            {
                string errorMessage = await _authService.Register(model);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = errorMessage });
                }
                return Ok(new ResponseDto { IsSuccess = true, Message = "Registration successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto { IsSuccess = false, Message = "Internal server error" });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var loginResponse = await _authService.Login(model);
                if (loginResponse.User == null)
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = "Username or password is incorrect" });
                }
                return Ok(new ResponseDto { IsSuccess = true, Result = loginResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto { IsSuccess = false, Message = "Internal server error" });
            }
        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> Login([FromBody] RegistrationDto model)
        {

            var assignRole = await _authService.AssigRole(model.Email, model.Role.ToUpper());
            if (!assignRole)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Encounter";
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = "Invalid input data" });
                }


                var updateProfileResult = await _authService.UpdateProfile(User.Identity.Name, model);

                if (updateProfileResult.IsSuccess)
                {
                    return Ok(new ResponseDto { IsSuccess = true, Message = "Profile updated successfully" });
                }
                else
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = updateProfileResult.Message });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto { IsSuccess = false, Message = "Internal server error" });
            }
        }
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _authService.FindUserByUsernameAsync(username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpPost("adwin-login")]
        public async Task<IActionResult> AdwinLogin([FromBody] AdwinLoginDto model)
        {
            try
            {
                var loginResponse = await _authService.AdwinLogin(model);

                if (loginResponse.User == null)
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = "Username or password is incorrect" });
                }

                return Ok(new ResponseDto { IsSuccess = true, Result = loginResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto { IsSuccess = false, Message = "Internal server error" });
            }
        }

        [HttpPost("adwin-register")]
        public async Task<IActionResult> AdwinRegister([FromBody] AdwinRegistrationDto model)
        {
            try
            {
                string errorMessage = await _authService.AdwinRegister(model);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = errorMessage });
                }

                return Ok(new ResponseDto { IsSuccess = true, Message = "Registration successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto { IsSuccess = false, Message = "Internal server error" });
            }
        }

        [HttpPost("compare-password")]
        public IActionResult ComparePassword([FromBody] PasswordCheckDto model)
        {
            try
            {
                // Get the stored password hash from the database using the username
                var storedPasswordHash = _authService.GetPasswordHash(model.user);

                if (storedPasswordHash == null)
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = "User not found" });
                }

                // Generate a compatible salt for both hashing and verifying
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                // Hash the incoming password using the generated salt
                string incomingPasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password, salt);

                // Compare the hashed incoming password with the stored hash
                bool passwordMatches = BCrypt.Net.BCrypt.Verify(incomingPasswordHash, storedPasswordHash);

                if (passwordMatches)
                {
                    return Ok(new ResponseDto { IsSuccess = true, Message = "Password matches" });
                }
                else
                {
                    return BadRequest(new ResponseDto { IsSuccess = false, Message = "Password does not match" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto { IsSuccess = false, Message = "Internal server error" });
            }
        }


    }
}
