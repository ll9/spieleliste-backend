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
    public class ListEntryConfiguration : IEntityTypeConfiguration<ListEntry>
    {
        public void Configure(EntityTypeBuilder<ListEntry> builder)
        {
            builder.HasKey(e => e.IgdbId);
        }
    }
}
