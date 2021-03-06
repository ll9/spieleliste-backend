﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spieleliste_backend.Repositories;

namespace spieleliste_backend.Data
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ListenEintraege = new ListenEintragRepository(_context);
            Users = new UserRepository(_context);
            UserEntries = new UserEntryRepository(_context);
            ArchiveEntries = new ArchiveRepository(_context);
        }

        public IListenEintragRepository ListenEintraege { get; set; }
        public IUserRepository Users { get; set; }
        public IUserEntryRepository UserEntries { get; set; }
        public IArchiveRepository ArchiveEntries { get; set; }

        public Task Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}
