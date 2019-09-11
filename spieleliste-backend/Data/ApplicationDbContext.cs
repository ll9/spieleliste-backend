using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data.Configurations;
using spieleliste_backend.Models;
using System.Threading.Tasks;

namespace spieleliste_backend.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ListenEintrag> ListenEintraege { get; set; }

        public Task Complete()
        {
            return SaveChangesAsync();
        }

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