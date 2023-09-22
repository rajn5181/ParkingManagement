using CheckStatus.Data;
using CheckStatus.Model;
using CheckStatus.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckStatus.Services
{
    public class SlotRepository : ISlotRepository
    {
        private readonly AppDbContext _context;

        public SlotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SlotModel>> GetAllSlots()
        {
            return await _context.MasterSlot.ToListAsync();
        }

        public async Task<SlotModel> GetSlot(string id)
        {
            return await _context.MasterSlot.FindAsync(id);
        }

        public async Task<SlotModel> CreateSlot(SlotModel slot)
        {
            _context.MasterSlot.Add(slot);
            await _context.SaveChangesAsync();
            return slot;
        }

        public async Task<bool> UpdateSlot(string id, SlotModel slot)
        {
            if (id != slot.Id)
            {
                return false;
            }

            _context.Entry(slot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSlot(string id)
        {
            var slot = await _context.MasterSlot.FindAsync(id);
            if (slot == null)
            {
                return false;
            }

            _context.MasterSlot.Remove(slot);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
