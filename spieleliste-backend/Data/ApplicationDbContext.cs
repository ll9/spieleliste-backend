using Microsoft.EntityFrameworkCore;
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

        public DbSet<ListenEintrag> ListenEintraege { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEintrag> UserEintraege { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListenEintragConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserEintragConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}