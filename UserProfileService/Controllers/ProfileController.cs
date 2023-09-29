using Microsoft.AspNetCore.Mvc;
using UserProfileService.Service.IService;
using UserProfileService.Model;
using System;
using System.Collections.Generic; // Import the List type

namespace UserProfileService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("FetchUserData")]
        public IActionResult FetchUserDataByUserId(string userId)
        {
            try
            {
                List<ProfileModel> profiles = _profileService.FetchUserDataByUserId(userId); 

                if (profiles != null && profiles.Count > 0)
                {
                    return Ok(profiles);
                }
                else
                {
                    return NotFound($"User with ID {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("FetchUserProfile")]
       
        public IActionResult FetchUserProfileByUserEmail(string userEmail)
        {
            try
            {
                ProfileModel profile = _profileService.FetchUserDataByUserEmail(userEmail);

                if (profile != null)
                {
                    return Ok(profile);
                }
                else
                {
                    return NotFound($"User with Email {userEmail} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
