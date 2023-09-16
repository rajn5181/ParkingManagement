using AuthService.Models.Dto;
using AuthService.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _responseDto;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
                _responseDto.IsSuccess= false;
                _responseDto.Message = "Error Encounter";
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }
    }
}
