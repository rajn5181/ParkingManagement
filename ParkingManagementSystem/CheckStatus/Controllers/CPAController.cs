using CheckStatus.Data;
using CheckStatus.Model;
using CheckStatus.Services;
using CheckStatus.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
namespace CheckStatus.Controllers
{
    [Route("api/cpa")]
    [ApiController]
    public class CPAController : ControllerBase
    {
        private readonly ICPARepository _cpaRepository;

        public CPAController(ICPARepository cpaRepository)
        {
            _cpaRepository = cpaRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPA>>> GetCPAs()
        {
            var cpas = await _cpaRepository.GetAllCPAs();
            return Ok(cpas);
        }

        [HttpGet("search-by-location")]
        public async Task<ActionResult<IEnumerable<CPA>>> SearchCPAsByLocation([FromQuery] string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                return BadRequest("Location parameter is required.");
            }

            var matchingCPAs = await _cpaRepository.SearchCPAsByLocation(location);

            if (matchingCPAs.Count() == 0)
            {
                return NotFound("No CPAs found for the specified location.");
            }

            return Ok(matchingCPAs);
        }

        [HttpGet("by-date/{date}")]
        public async Task<ActionResult<IEnumerable<CPA>>> GetCPAsByDate(string date)
        {
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime parsedDate))
            {
                var cpas = await _cpaRepository.GetCPAsByDate(parsedDate);

                if (cpas.Count() == 0)
                {
                    return NotFound("No CPAs available for the specified date.");
                }

                return Ok(cpas);
            }
            else
            {
                return BadRequest("Invalid date format. Please use the format 'yyyy-MM-dd'.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CPA>> GetCPA(string id)
        {
            var cpa = await _cpaRepository.GetCPA(id);

            if (cpa == null)
            {
                return NotFound("CPA not found.");
            }

            return Ok(cpa);
        }

        [HttpPost]
        public async Task<ActionResult<CPA>> PostCPA([FromBody] CPA cpa)
        {
            if (cpa == null || cpa.Available == DateTime.MinValue)
            {
                return BadRequest("The 'cpa' object with 'Available' field is required.");
            }

            try
            {
                var createdCPA = await _cpaRepository.CreateCPA(cpa);

                return CreatedAtAction("GetCPA", new { id = createdCPA.Pid }, createdCPA);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCPA(string id, [FromBody] CPA updatedCPA)
        {
            if (string.IsNullOrEmpty(id) || updatedCPA == null || id != updatedCPA.Pid)
            {
                return BadRequest("Invalid input or ID mismatch.");
            }
            var existingCPA = await _cpaRepository.GetCPA(id);

            if (existingCPA == null)
            {
                return NotFound("CPA not found.");
            }

           
            existingCPA.Status = updatedCPA.Status;
            existingCPA.Available = updatedCPA.Available;
            existingCPA.location = updatedCPA.location;
      

          
            var updated = await _cpaRepository.UpdateCPA(id, existingCPA);

            if (!updated)
            {
                return StatusCode(500, "Failed to update CPA in the database.");
            }

            // Return the updated CPA in the response
            return Ok(existingCPA);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCPA(string id)
        {
            var deleted = await _cpaRepository.DeleteCPA(id);

            if (!deleted)
            {
                return NotFound("CPA not found.");
            }

            return NoContent();
        }
    }
}
