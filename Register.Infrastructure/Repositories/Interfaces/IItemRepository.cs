using Register.Domain;
using Register.Infrastructure.Models;

namespace Register.Infrastructure.Repositories.Interfaces
{
    public interface IItemRepository : IGeneralRepository
    {
        Task<PageList<Item>> GetAllItemsPageListAsync(PageParams pageParams);
        Task<Item> GetItemByIdAsync(string id);

    }
}