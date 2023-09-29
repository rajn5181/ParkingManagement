using System.Collections.Generic;
using System.Threading.Tasks;
using CheckStatus.Model;

namespace CheckStatus.Services.IServices
{
    public interface ISlotRepository
    {
        Task<IEnumerable<SlotModel>> GetAllSlots();
        Task<SlotModel> GetSlot(string id);
        Task<SlotModel> CreateSlot(SlotModel slot);
        Task<bool> UpdateSlot(string id, SlotModel slot);
        Task<bool> DeleteSlot(string id);
    }
}
