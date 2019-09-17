﻿using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data;
using spieleliste_backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class UserEntryRepository : IRepository<UserEntry>
    {
        private readonly ApplicationDbContext _context;

        public UserEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntry> Add(UserEntry entry)
        {
            await _context.UserEntries.AddAsync(entry);
            return entry;
        }

        public async Task<UserEntry> Get(int id)
        {
            var entry = await _context.UserEntries.FindAsync(id);
            return entry;
        }

        public async Task<IEnumerable<UserEntry>> List()
        {
            var entries = await _context.UserEntries.ToListAsync();
            return entries;
        }

        public async Task<IEnumerable<UserEntry>> ListByUser(int userId)
        {
            var entries = await _context.UserEntries.Where(e => e.UserId == userId).ToListAsync();
            return entries;
        }

        public Task Remove(UserEntry entry)
        {
            _context.UserEntries.Remove(entry);
            return Task.CompletedTask;
        }

        public Task<UserEntry> Update(UserEntry entry)
        {
            _context.UserEntries.Update(entry);
            return Task.FromResult(entry);
        }
    }
}
