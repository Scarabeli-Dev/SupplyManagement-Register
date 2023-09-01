using AutoMapper;
using Register.Application.Dtos;
using Register.Application.Services.Interfaces;
using Register.Domain;
using Register.Infrastructure.Models;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Application.Services
{
    public class ItemsAddressingsService : IItemsAddressingsService
    {
        private readonly IItemsAddressingsRepository _itemsAddressingsRepository;
        private readonly IMapper _mapper;

        public ItemsAddressingsService(IItemsAddressingsRepository itemsAddressingsRepository, IMapper mapper)
        {
            _itemsAddressingsRepository = itemsAddressingsRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddItemsAddressings(List<ItemsAddressingDto> itemsAddressingDto)
        {
            try
            {
                var item = _mapper.Map<List<ItemsAddressing>>(itemsAddressingDto);

                _itemsAddressingsRepository.AddRangeAsync(item);

                if (await _itemsAddressingsRepository.SaveChangesAsync())
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

        public async Task<bool> DeleteItemsAddressing(string itemId, int addressingId)
        {
            try
            {
                var itemAddressingToDelete = await _itemsAddressingsRepository.GetItemsAddressingByIdsAsync(itemId, addressingId);
                var itemAddressing = _mapper.Map<ItemsAddressing>(itemAddressingToDelete);

                _itemsAddressingsRepository.Delete(itemAddressing);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<PageList<ItemsAddressingDto>> GetAllItemsAddressingsPageListAsync(PageParams pageParams)
        {
            throw new NotImplementedException();
        }

        public Task<ItemsAddressingDto> GetItemsAddressingByIdsAsync(string itemId, int addressingId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemsAddressing(int addressingId, ItemsAddressingDto itemDto)
        {
            throw new NotImplementedException();
        }
    }
}
