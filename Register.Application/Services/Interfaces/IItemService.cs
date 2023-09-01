using Register.Application.Dtos;
using Register.Infrastructure.Models;

namespace Register.Application.Services.Interfaces
{
    public interface IItemService
    {
        Task<bool> AddItem(ItemDto itemDto);
        Task<bool> UpdateItem(string itemId, ItemDto itemDto);
        Task<bool> DeleteItem(string itemId);
        Task<PageList<ItemDto>> GetAllItemsPageListAsync(PageParams pageParams);
        Task<ItemDto> GetItemByIdAsync(string itemId);
    }
}