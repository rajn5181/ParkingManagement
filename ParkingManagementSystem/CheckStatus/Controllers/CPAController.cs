using CheckStatus.Data;
using CheckStatus.Model;
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
        private readonly AppDbContext _context;

        public CPAController(AppDbContext context)
        {
            _context = context;
        }


        private const string DateFormat = "dd/MM/yyyy";

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPA>>> GetCPAs()
        {
            var cpas = await _context.MasterAvailability.ToListAsync();
            return Ok(cpas);
        }
        [HttpGet("search-by-location")]
        public async Task<ActionResult<IEnumerable<CPA>>> SearchCPAsByLocation([FromQuery] string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                return BadRequest("Location parameter is required.");
            }

            // Assuming you have a DbSet for locations in your AppDbContext
            var matchingCPAs = await _context.MasterAvailability
                .Where(cpa => cpa.location.Contains(location) && cpa.Status)
                .ToListAsync();

            if (matchingCPAs.Count == 0)
            {
                return NotFound("No CPAs found for the specified location.");
            }

            // Here you can perform a web search using the 'location' parameter
            // and incorporate the search results into the response if needed.

            return Ok(matchingCPAs);
        }

        [HttpGet("by-date/{date}")]
        public async Task<ActionResult<IEnumerable<CPA>>> GetCPAsByDate(string date)
        {
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                var cpas = await _context.MasterAvailability
                .Where(cpa => cpa.Available.Date == parsedDate.Date && cpa.Status)
                .Include(cpa => cpa.Slots)
                .ToListAsync();

                if (cpas.Count == 0)
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
            var cpa = await _context.MasterAvailability.FindAsync(id);

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
                // Parse the date string from the request body in the format "dd-MM-yyyy"
                if (DateTime.TryParseExact(cpa.Available.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    cpa.Available = parsedDate; // Update the CPA object with the formatted date

                    // Remove the time portion of the DateTime
                    cpa.Available = cpa.Available.Date;

                    _context.MasterAvailability.Add(cpa);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetCPA", new { id = cpa.Pid }, cpa);
                }
                else
                {
                    return BadRequest("Invalid date format. Please use the format 'dd-MM-yyyy'.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutCPA(string id, [FromBody] CPA cpa)
        {
            if (id != cpa.Pid)
            {
                return BadRequest("ID mismatch.");
            }

            _context.Entry(cpa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPAExists(id))
                {
                    return NotFound("CPA not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCPA(string id)
        {
            var cpa = await _context.MasterAvailability.FindAsync(id);
            if (cpa == null)
            {
                return NotFound("CPA not found.");
            }

            _context.MasterAvailability.Remove(cpa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CPAExists(string id)
        {
            return _context.MasterAvailability.Any(e => e.Pid == id);
        }
    }
}
