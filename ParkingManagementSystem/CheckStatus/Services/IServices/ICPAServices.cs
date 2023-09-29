using CheckStatus.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckStatus.Services.IServices
{
    public interface ICPARepository
    {
        Task<IEnumerable<CPA>> GetAllCPAs();
        Task<IEnumerable<CPA>> SearchCPAsByLocation(string location);
        Task<IEnumerable<CPA>> GetCPAsByDate(DateTime date);
        Task<CPA> GetCPA(string id);
        Task<CPA> CreateCPA(CPA cpa);
        Task<bool> UpdateCPA(string id, CPA cpa);
        Task<bool> DeleteCPA(string id);
    }
}
