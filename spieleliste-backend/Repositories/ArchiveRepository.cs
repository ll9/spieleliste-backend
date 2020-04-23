using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data;
using spieleliste_backend.Dtos;
using spieleliste_backend.Helper;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spieleliste_backend.Repositories
{
    public class ArchiveRepository : IArchiveRepository
    {
        private readonly ApplicationDbContext _context;

        public ArchiveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArchiveEntry>> List()
        {
            return await _context.ArchiveEntries
                .OrderByDescending(e => e.Archived)
                .ToListAsync();
        }

        public async Task<PagedList<ArchiveEntry>> List(ResourceParameters resourceParameters)
        {
            var query = _context.ArchiveEntries.OrderByDescending(e => e.Archived);
            return await PagedList<ArchiveEntry>.Create(query, resourceParameters);
        }

        public async Task<ArchiveEntry> Get(int id)
        {
            return await _context.ArchiveEntries.FindAsync(id);
        }

        public Task Delete(ArchiveEntry archiveEntry)
        {
            _context.ArchiveEntries.Remove(archiveEntry);
            return Task.CompletedTask;
        }

        public Task<ArchiveEntry> Create(ArchiveEntry archiveEntry)
        {
            _context.ArchiveEntries.Add(archiveEntry);
            return Task.FromResult(archiveEntry);
        }
    }
}