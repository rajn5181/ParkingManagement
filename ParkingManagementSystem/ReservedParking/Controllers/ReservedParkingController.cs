using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservedParking.Data;
using ReservedParking.Models;
using ReservedParking.Services.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservedParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservedParkingController : ControllerBase
    {
        private readonly IReservedService _repository;

        public ReservedParkingController(IReservedService repository)
        {
            _repository = repository;
        }

        // GET: api/ReservedParking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RGPModel>>> GetRGPModels()
        {
            var rgpModels = await _repository.GetAllAsync();
            return rgpModels.ToList();
        }

        // GET: api/ReservedParking/id
        [HttpGet("{id}")]
        public async Task<ActionResult<RGPModel>> GetRGPModel(string id)
        {
            var rgpModel = await _repository.GetByIdAsync(id);

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
            await _repository.CreateAsync(rgpModel);

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

            await _repository.UpdateAsync(rgpModel);

            return NoContent();
        }

        // DELETE: api/ReservedParking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRGPModel(string id)
        {
            if (!_repository.Exists(id))
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);

            return Ok("Deleted Successfully");
        }
    }

}
