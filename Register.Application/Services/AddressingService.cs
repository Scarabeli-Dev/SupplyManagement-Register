using AutoMapper;
using Register.Application.Dtos;
using Register.Application.Services.Interfaces;
using Register.Domain;
using Register.Infrastructure.Models;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Application.Services
{
    public class AddressingService : IAddressingService
    {
        private readonly IAddressingRepository _addressingRepository;
        private readonly IMapper _mapper;

        public AddressingService(IAddressingRepository addressingRepository, IMapper mapper)
        {
            _addressingRepository = addressingRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAddressing(AddressingDto addressingDto)
        {
            try
            {
                var addressing = _mapper.Map<Addressing>(addressingDto);

                _addressingRepository.Add<Addressing>(addressing);

                if (await _addressingRepository.SaveChangesAsync())
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

        public async Task<bool> UpdateAddressing(int addressingId, AddressingDto addressingDto)
        {
            try
            {
                var addressing = await _addressingRepository.GetAddressingByIdAsync(addressingId);
                if (addressing == null) return false;

                addressingDto.Id = addressing.Id;

                _mapper.Map(addressingDto, addressing);

                _addressingRepository.Update<Addressing>(addressing);

                if (await _addressingRepository.SaveChangesAsync())
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

        public async Task<bool> DeleteAddressing(int addressingId)
        {
            try
            {
                var addressing = await _addressingRepository.GetAddressingByIdAsync(addressingId);
                if (addressing == null) throw new Exception("Fazenda para delete não encontrado.");


                _addressingRepository.Delete<Addressing>(addressing);
                return await _addressingRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<AddressingDto>> GetAllAddressingsPageListAsync(PageParams pageParams)
        {
            try
            {
                var addressings = await _addressingRepository.GetAllAddressingsPageListAsync(pageParams);
                if (addressings == null) return null;

                var result = _mapper.Map<PageList<AddressingDto>>(addressings);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<AddressingDto> GetAddressingByIdAsync(int addressingId)
        {
            try
            {
                var addressing = await _addressingRepository.GetAddressingByIdAsync(addressingId);
                if (addressing == null) return null;

                var result = _mapper.Map<AddressingDto>(addressing);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
