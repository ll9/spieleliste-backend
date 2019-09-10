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
    public class ListenEintragConfiguration : IEntityTypeConfiguration<ListenEintrag>
    {
        public void Configure(EntityTypeBuilder<ListenEintrag> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.SpielId);
        }
    }
}
