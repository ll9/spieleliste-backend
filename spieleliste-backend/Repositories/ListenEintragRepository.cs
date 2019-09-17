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

        public async Task<ListEntry> Add(ListEntry entry)
        {
            await _context.ListEntries.AddAsync(entry);
            return entry;
        }

        public async Task<ListEntry> Get(int id)
        {
            return await _context.ListEntries.SingleOrDefaultAsync(e => e.SpielId == id);
        }

        public Task Remove(ListEntry entry)
        {
            _context.Remove(entry);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ListEntry>> List()
        {
            return await _context.ListEntries.ToListAsync();
        }
    }
}