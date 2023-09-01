using Microsoft.EntityFrameworkCore;
using Register.Domain;
using Register.Infrastructure.Context;
using Register.Infrastructure.Models;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Infrastructure.Repositories
{
    public class AddressingRepository : GeneralRepository, IAddressingRepository
    {
        private readonly RegisterApiContext _context;

        public AddressingRepository(RegisterApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Addressing>> GetAllAddressingsPageListAsync(PageParams pageParams)
        {
            IQueryable<Addressing> query = _context.Addressings.Include(w => w.Warehouse)
                                                               .Include(ia => ia.Item).ThenInclude(i => i.Item);

            query = query.AsNoTracking()
                         .Where(e => (e.Name.ToLower().Contains(pageParams.Term.ToLower())))
                         .OrderBy(e => e.Id);

            return await PageList<Addressing>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<Addressing> GetAddressingByIdAsync(int id)
        {
            IQueryable<Addressing> query = _context.Addressings.Include(w => w.Warehouse);

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
