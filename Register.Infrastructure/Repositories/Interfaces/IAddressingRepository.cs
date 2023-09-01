using Register.Domain;
using Register.Infrastructure.Models;

namespace Register.Infrastructure.Repositories.Interfaces
{
    public interface IAddressingRepository : IGeneralRepository
    {
        Task<PageList<Addressing>> GetAllAddressingsPageListAsync(PageParams pageParams);
        Task<Addressing> GetAddressingByIdAsync(int id);
    }
}
