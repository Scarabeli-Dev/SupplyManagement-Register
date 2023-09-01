using Microsoft.EntityFrameworkCore;
using Register.Domain;
using Register.Infrastructure.Context;
using Register.Infrastructure.Models;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Infrastructure.Repositories
{
    public class ItemRepository : GeneralRepository, IItemRepository
    {
        private readonly RegisterApiContext _context;

        public ItemRepository(RegisterApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Item>> GetAllItemsPageListAsync(PageParams pageParams)
        {
            IQueryable<Item> query = _context.Items.Include(ia => ia.Addressings).ThenInclude(a => a.Addressing);

            query = query.AsNoTracking()
                         .Where(e => (e.Name.ToLower().Contains(pageParams.Term.ToLower())))
                         .OrderBy(e => e.Id);

            return await PageList<Item>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<Item> GetItemByIdAsync(string id)
        {
            IQueryable<Item> query = _context.Items.Include(w => w.Addressings).ThenInclude(a => a.Addressing);

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
