using Register.Application.Dtos;
using Register.Infrastructure.Models;

namespace Register.Application.Services.Interfaces
{
    public interface IAddressingService
    {
        Task<PageList<AddressingDto>> GetAllAddressingsPageListAsync(PageParams pageParams);
        Task<AddressingDto> GetAddressingByIdAsync(int addressingId);
        Task<bool> AddAddressing(AddressingDto addressingDto);
        Task<bool> UpdateAddressing(int addressingId, AddressingDto addressingDto);
        Task<bool> DeleteAddressing(int addressingId);
    }
}
