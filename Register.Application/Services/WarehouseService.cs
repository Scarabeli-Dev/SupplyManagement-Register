using AutoMapper;
using Register.Application.Dtos;
using Register.Application.Services.Interfaces;
using Register.Infrastructure.Models;
using Register.Domain;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddWarehouse(WarehouseDto warehouseDto)
        {
            try
            {
                var warehouse = _mapper.Map<Warehouse>(warehouseDto);

                _warehouseRepository.Add<Warehouse>(warehouse);

                if (await _warehouseRepository.SaveChangesAsync())
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateWarehouse(int warehouseId, WarehouseDto warehouseDto)
        {
            try
            {
                var warehouse = await _warehouseRepository.GetWarehouseByIdAsync(warehouseId);
                if (warehouse == null) return false;

                warehouseDto.Id = warehouse.Id;

                _mapper.Map(warehouseDto, warehouse);

                _warehouseRepository.Update<Warehouse>(warehouse);

                if (await _warehouseRepository.SaveChangesAsync())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteWarehouse(int warehouseId)
        {
            try
            {
                var warehouse = await _warehouseRepository.GetWarehouseByIdAsync(warehouseId);
                if (warehouse == null) throw new Exception("Fazenda para delete não encontrado.");

                _warehouseRepository.Delete<Warehouse>(warehouse);
                return await _warehouseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<WarehouseDto>> GetAllWarehousesPageListAsync(PageParams pageParams)
        {
            try
            {
                var warehouses = await _warehouseRepository.GetAllWarehousesPageListAsync(pageParams);
                if (warehouses == null) return null;

                var result = _mapper.Map<PageList<WarehouseDto>>(warehouses);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<WarehouseDto> GetWarehouseByIdAsync(int warehouseId)
        {
            try
            {
                var warehouse = await _warehouseRepository.GetWarehouseByIdAsync(warehouseId);
                if (warehouse == null) return null;

                var result = _mapper.Map<WarehouseDto>(warehouse);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
