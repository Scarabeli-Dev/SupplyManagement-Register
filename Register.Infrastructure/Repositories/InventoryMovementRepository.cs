using Register.Infrastructure.Context;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.Infrastructure.Repositories
{
    public class InventoryMovementRepository : GeneralRepository, IInventoryMovementRepository
    {
        private readonly RegisterApiContext _context;

        public InventoryMovementRepository(RegisterApiContext context) : base(context)
        {
            _context = context;
        }
    }
}
