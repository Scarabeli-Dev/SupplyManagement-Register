using Microsoft.EntityFrameworkCore;
using Register.Domain;
using Register.Infrastructure.Context;
using Register.Infrastructure.Models;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Infrastructure.Repositories
{
    public class ItemsAddressingsRepository : GeneralRepository, IItemsAddressingsRepository
    {
        private readonly RegisterApiContext _context;

        public ItemsAddressingsRepository(RegisterApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<ItemsAddressing>> GetAllItemsAddressingPageListAsync(PageParams pageParams)
        {
            IQueryable<ItemsAddressing> query = _context.ItemsAddressings.Include(a => a.Addressing)
                                                                         .Include(i => i.Item);

            query = query.AsNoTracking()
                         .Where(e => (e.Addressing.Name.ToLower().Contains(pageParams.Term.ToLower())) ||
                                     (e.Item.Name.ToLower().Contains(pageParams.Term.ToLower())))
                         .OrderBy(e => e.Id);

            return await PageList<ItemsAddressing>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<ItemsAddressing> GetItemsAddressingByIdsAsync(string itemId, int addressingId)
        {
            IQueryable<ItemsAddressing> query = _context.ItemsAddressings.Include(a => a.Addressing)
                                                                         .Include(i => i.Item);

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => (e.AddressingId == addressingId) && 
                        (e.ItemId == itemId));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ItemsAddressing> GetItemsAddressingByAddressingIdAsync(int addressingId)
        {
            IQueryable<ItemsAddressing> query = _context.ItemsAddressings.Include(a => a.Addressing)
                                                                         .Include(i => i.Item);

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.AddressingId == addressingId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PageList<ItemsAddressing>> GetItemsAddressingByWarehouseIdAsync(PageParams pageParams, int warehouseId)
        {
            IQueryable<ItemsAddressing> query = _context.ItemsAddressings.Include(a => a.Addressing)
                                                                         .Include(i => i.Item);

            query = query.AsNoTracking()
                         .Where(a => a.Addressing.WarehouseId == warehouseId)
                         .Where(e => (e.Addressing.Name.ToLower().Contains(pageParams.Term.ToLower())) ||
                                     (e.Item.Name.ToLower().Contains(pageParams.Term.ToLower())))
                         .OrderBy(e => e.Id);

            return await PageList<ItemsAddressing>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }
    }
}
