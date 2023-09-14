using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservedParking.Data;
using ReservedParking.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservedParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservedParkingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservedParkingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservedParking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RGPModel>>> GetRGPModels()
        {
            var rgpModels = await _context.MasterReserved.ToListAsync();
            return rgpModels;
        }

        // GET: api/ReservedParking/id
        [HttpGet("{id}")]
        public async Task<ActionResult<RGPModel>> GetRGPModel(string id)
        {
            var rgpModel = await _context.MasterReserved.FindAsync(id);

            if (rgpModel == null)
            {
                return NotFound();
            }

            return rgpModel;
        }

        // POST: api/ReservedParking
        [HttpPost]
        public async Task<ActionResult<RGPModel>> PostRGPModel(RGPModel rgpModel)
        {
            _context.MasterReserved.Add(rgpModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRGPModel), new { id = rgpModel.Rpid }, rgpModel);
        }

        // PUT: api/ReservedParking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRGPModel(string id, RGPModel rgpModel)
        {
            if (id != rgpModel.Rpid)
            {
                return BadRequest();
            }

            _context.Entry(rgpModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RGPModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ReservedParking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRGPModel(string id)
        {
            var rgpModel = await _context.MasterReserved.FindAsync(id);
            if (rgpModel == null)
            {
                return NotFound();
            }

            _context.MasterReserved.Remove(rgpModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RGPModelExists(string id)
        {
            return _context.MasterReserved.Any(e => e.Rpid == id);
        }
    }
}
