using Register.Application.Dtos;
using Register.Infrastructure.Models;

namespace Register.Application.Services.Interfaces
{
    public interface IItemsAddressingsService
    {
        Task<bool> AddItemsAddressings(List<ItemsAddressingDto> itemsAddressingDto);
        Task<bool> UpdateItemsAddressing(int addressingId, ItemsAddressingDto itemDto);
        Task<bool> DeleteItemsAddressing(string itemId, int addressingId);
        Task<PageList<ItemsAddressingDto>> GetAllItemsAddressingsPageListAsync(PageParams pageParams);
        Task<ItemsAddressingDto> GetItemsAddressingByIdsAsync(string itemId, int addressingId);
    }
}