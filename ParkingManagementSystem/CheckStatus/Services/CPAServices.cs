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
    public class CPARepository : ICPARepository
    {
        private readonly AppDbContext _context;

        public CPARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CPA>> GetAllCPAs()
        {
            return await _context.MasterAvailability
               .Include(cpa => cpa.Slots) 
               .ToListAsync();
        }

        public async Task<IEnumerable<CPA>> SearchCPAsByLocation(string location)
        {
            return await _context.MasterAvailability
                .Where(cpa => cpa.location.ToLower().Contains(location.ToLower())).Include(cpa=>cpa.Slots)
                .ToListAsync();
        }

        public async Task<IEnumerable<CPA>> GetCPAsByDate(DateTime date)
        {
            return await _context.MasterAvailability.Where(cpa => cpa.Available.Date == date.Date).Include(cpa => cpa.Slots)
                .ToListAsync();
        }

        public async Task<CPA> GetCPA(string id)
        {
            return await _context.MasterAvailability
                .Include(cpa => cpa.Slots)
                .FirstOrDefaultAsync(cpa => cpa.Pid == id);
        }


        public async Task<CPA> CreateCPA(CPA cpa)
        {
           
            _context.MasterAvailability.Add(cpa);
            
            await _context.SaveChangesAsync();
            return cpa;
        }

        public async Task<bool> UpdateCPA(string id, CPA cpa)
        {
            if (id != cpa.Pid)
            {
                return false;
            }

            _context.Entry(cpa).State = EntityState.Modified;

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

        public async Task<bool> DeleteCPA(string id)
        {
            var cpa = await _context.MasterAvailability.FindAsync(id);
            if (cpa == null)
            {
                return false;
            }

            _context.MasterAvailability.Remove(cpa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
