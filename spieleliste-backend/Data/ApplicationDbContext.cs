﻿using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data.Configurations;
using spieleliste_backend.Models;
using System.Threading.Tasks;

namespace spieleliste_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ListEntry> ListEntries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEntry> UserEntries { get; set; }
        public DbSet<ArchiveEntry> ArchiveEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListEntryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserEintragConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}