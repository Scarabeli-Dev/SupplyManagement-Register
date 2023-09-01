using Register.Infrastructure.Context;
using Register.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Register.Infrastructure.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly RegisterApiContext _context;

        public GeneralRepository(RegisterApiContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void AddRangeAsync<T>(T entity) where T : class
        {
            _context.AddRangeAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void UpdateRange<T>(T entity) where T : class
        {
            _context.UpdateRange(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
