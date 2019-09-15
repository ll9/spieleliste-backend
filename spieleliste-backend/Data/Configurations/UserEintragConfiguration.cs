using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spieleliste_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Data.Configurations
{
    public class UserEintragConfiguration : IEntityTypeConfiguration<UserEntry>
    {
        public void Configure(EntityTypeBuilder<UserEntry> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithMany(e => e.UserEntries);

            builder
                .HasOne(e => e.ListEntry)
                .WithMany();
        }
    }
}
