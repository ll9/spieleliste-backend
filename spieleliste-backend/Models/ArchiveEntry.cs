using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class ArchiveEntry
    {
        public int Id { get; set; }
        public int IgdbId { get; set; }
        public DateTime Archived { get; set; }
    }
}
