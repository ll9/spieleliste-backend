using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data.Configurations;
using spieleliste_backend.Models;

namespace spieleliste_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ListenEintrag> ListenEintraege { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListenEintragConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}