using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spieleliste_backend.Repositories
{
    public class UserRepository : IRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        private ApplicationDbContext _context { get; set; }

        public async Task<User> Add(User entry)
        {
            await _context.Users.AddAsync(entry);
            return entry;
        }

        public async Task<User> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> List()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> ListWithUserEntries()
        {
            var users = await _context.Users.Include(u => u.UserEntries).ToListAsync();
            users.ForEach(u => u.UserEntries = u.UserEntries.OrderBy(_ => _.Index).ToList());
            return users;
        }

        public Task Remove(User entry)
        {
            _context.Users.Remove(entry);
            return Task.CompletedTask;
        }

        public Task<User> Update(User entry)
        {
            _context.Users.Update(entry);
            return Task.FromResult(entry);
        }
    }
}