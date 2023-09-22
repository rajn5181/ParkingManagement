using Microsoft.EntityFrameworkCore;
using ReservedParking.Data;
using ReservedParking.Models;
using ReservedParking.Services.IServices;

namespace ReservedParking.Services
{
    public class ReservedService : IReservedService
    {
        private readonly AppDbContext _context;

        public ReservedService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RGPModel>> GetAllAsync()
        {
            return await _context.MasterReserved.ToListAsync();
        }

        public async Task<RGPModel> GetByIdAsync(string id)
        {
            return await _context.MasterReserved.FindAsync(id);
        }

        public async Task CreateAsync(RGPModel rgpModel)
        {
            _context.MasterReserved.Add(rgpModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RGPModel rgpModel)
        {
            _context.Entry(rgpModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var rgpModel = await _context.MasterReserved.FindAsync(id);
            if (rgpModel != null)
            {
                _context.MasterReserved.Remove(rgpModel);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(string id)
        {
            return _context.MasterReserved.Any(e => e.Rpid == id);
        }
    }
}
