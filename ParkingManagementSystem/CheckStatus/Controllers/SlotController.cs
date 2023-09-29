using CheckStatus.Model;
using CheckStatus.Services;
using CheckStatus.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckStatus.Controllers
{
    [Route("api/slots")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotRepository _slotRepository;

        public SlotController(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlotModel>>> GetSlots()
        {
            var slots = await _slotRepository.GetAllSlots();
            return Ok(slots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SlotModel>> GetSlot(string id)
        {
            var slot = await _slotRepository.GetSlot(id);

            if (slot == null)
            {
                return NotFound("Slot not found.");
            }

            return Ok(slot);
        }

        [HttpPost]
        public async Task<ActionResult<SlotModel>> PostSlot([FromBody] SlotModel slot)
        {
            try
            {
                var createdSlot = await _slotRepository.CreateSlot(slot);

                return CreatedAtAction("GetSlot", new { id = createdSlot.Id }, createdSlot);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlot(string id, [FromBody] SlotModel slot)
        {
            if (id != slot.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var updated = await _slotRepository.UpdateSlot(id, slot);

            if (!updated)
            {
                return NotFound("Slot not found.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot(string id)
        {
            var deleted = await _slotRepository.DeleteSlot(id);

            if (!deleted)
            {
                return NotFound("Slot not found.");
            }

            return NoContent();
        }
    }
}
