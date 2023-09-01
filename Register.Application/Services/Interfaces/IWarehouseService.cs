using Register.Application.Dtos;
using Register.Domain;
using Register.Infrastructure.Models;

namespace Register.Application.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<bool> AddWarehouse(WarehouseDto warehouseDto);
        Task<bool> UpdateWarehouse(int warehouseId, WarehouseDto warehouseDto);
        Task<bool> DeleteWarehouse(int warehouseId);
        Task<PageList<WarehouseDto>> GetAllWarehousesPageListAsync(PageParams pageParams);
        Task<WarehouseDto> GetWarehouseByIdAsync(int warehouseId);
    }
}