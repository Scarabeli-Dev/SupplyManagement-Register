using Register.Domain;
using Register.Infrastructure.Models;

namespace Register.Infrastructure.Repositories.Interfaces
{
    public interface IWarehouseRepository : IGeneralRepository
    {
        Task<PageList<Warehouse>> GetAllWarehousesPageListAsync(PageParams pageParams);
        Task<Warehouse> GetWarehouseByIdAsync(int id);
    }
}