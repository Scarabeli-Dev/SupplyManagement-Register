using AutoMapper;
using Register.Application.Dtos;
using Register.Application.Services.Interfaces;
using Register.Domain;
using Register.Infrastructure.Models;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemsAddressingsService _itemsAddressingsService;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper, IItemsAddressingsService itemsAddressingsService)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _itemsAddressingsService = itemsAddressingsService;
        }

        public async Task<bool> AddItem(ItemDto itemDto)
        {
            try
            {
                var item = _mapper.Map<Item>(itemDto);

                _itemRepository.Add<Item>(item);

                if (await _itemRepository.SaveChangesAsync())
                {
                    if (await _itemsAddressingsService.AddItemsAddressings(itemDto.Addressings.ToList()))
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateItem(string itemId, ItemDto itemDto)
        {
            try
            {
                var item = await _itemRepository.GetItemByIdAsync(itemId);
                if (item == null) return false;

                itemDto.Id = item.Id;

                _mapper.Map(itemDto, item);

                _itemRepository.Update<Item>(item);

                if (await _itemRepository.SaveChangesAsync())
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

        public async Task<bool> DeleteItem(string itemId)
        {
            try
            {
                var item = await _itemRepository.GetItemByIdAsync(itemId);
                if (item == null) throw new Exception("Fazenda para delete não encontrado.");


                _itemRepository.Delete<Item>(item);
                return await _itemRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<ItemDto>> GetAllItemsPageListAsync(PageParams pageParams)
        {
            try
            {
                var items = await _itemRepository.GetAllItemsPageListAsync(pageParams);
                if (items == null) return null;

                var result = _mapper.Map<PageList<ItemDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<ItemDto> GetItemByIdAsync(string itemId)
        {
            try
            {
                var item = await _itemRepository.GetItemByIdAsync(itemId);
                if (item == null) return null;

                var result = _mapper.Map<ItemDto>(item);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
