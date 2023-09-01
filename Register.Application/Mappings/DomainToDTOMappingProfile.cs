using AutoMapper;
using Register.Application.Dtos;
using Register.Domain;

namespace Register.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Addressing, AddressingDto>().ReverseMap();
            CreateMap<InventoryMovement, InventoryMovementDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<ItemsAddressing, ItemsAddressingDto>().ReverseMap();
            CreateMap<Warehouse, WarehouseDto>().ReverseMap();
        }
    }
}
