using Register.Domain;
using Register.Infrastructure.Models;

namespace Register.Infrastructure.Repositories.Interfaces
{
    public interface IItemsAddressingsRepository : IGeneralRepository
    {
        Task<PageList<ItemsAddressing>> GetAllItemsAddressingPageListAsync(PageParams pageParams);
        Task<ItemsAddressing> GetItemsAddressingByIdsAsync(string itemId, int addressingId);
        Task<ItemsAddressing> GetItemsAddressingByAddressingIdAsync(int addressingId);
        Task<PageList<ItemsAddressing>> GetItemsAddressingByWarehouseIdAsync(PageParams pageParams, int warehouseId);
    }
}