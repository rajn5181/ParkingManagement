using ReservedParking.Models;

namespace ReservedParking.Services.IServices
{
    public interface IReservedService
    {
        Task<IEnumerable<RGPModel>> GetAllAsync();
        Task<RGPModel> GetByIdAsync(string id);
        Task CreateAsync(RGPModel rgpModel);
        Task UpdateAsync(RGPModel rgpModel);
        Task DeleteAsync(string id);
        bool Exists(string id);
    }
}
