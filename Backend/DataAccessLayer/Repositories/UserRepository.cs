using Medfar.Interview.Types;
using Microsoft.EntityFrameworkCore;

namespace Medfar.Interview.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MedfarDbContext _context;

        public UserRepository(MedfarDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> InsertAsync(User u)
        {
            _context.Users.Add(u);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(User u)
        {
            _context.Users.Update(u);
            return await _context.SaveChangesAsync();
        }
    }
}
