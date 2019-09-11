using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace spieleliste_backend.Repositories
{
    public class ListenEintragRepository : IListenEintragRepository
    {
        private readonly ApplicationDbContext _context;

        public ListenEintragRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ListenEintrag> Add(ListenEintrag entry)
        {
            await _context.ListenEintraege.AddAsync(entry);
            return entry;
        }

        public Task<ListenEintrag> Get(int id)
        {
            return _context.ListenEintraege.SingleOrDefaultAsync(e => e.SpielId == id);
        }

        public Task Remove(ListenEintrag entry)
        {
            _context.Remove(entry);
            return Task.CompletedTask;
        }

        public Task<List<ListenEintrag>> List()
        {
            return _context.ListenEintraege.ToListAsync();
        }
    }
}