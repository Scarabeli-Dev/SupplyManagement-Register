using Register.Infrastructure.Models;
using Register.Infrastructure.Context;
using Register.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Register.Domain;

namespace Register.Infrastructure.Repositories
{
    public class WarehouseRepository : GeneralRepository, IWarehouseRepository
    {
        private readonly RegisterApiContext _context;

        public WarehouseRepository(RegisterApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Warehouse>> GetAllWarehousesPageListAsync(PageParams pageParams)
        {
            IQueryable<Warehouse> query = _context.Warehouses;

            query = query.AsNoTracking()
                         .Where(e => (e.Name.ToLower().Contains(pageParams.Term.ToLower())))
                         .OrderBy(e => e.Id);

            return await PageList<Warehouse>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<Warehouse> GetWarehouseByIdAsync(int id)
        {
            IQueryable<Warehouse> query = _context.Warehouses;

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
