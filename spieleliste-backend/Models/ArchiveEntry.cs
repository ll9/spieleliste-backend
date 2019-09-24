using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class ArchiveEntry
    {
        public ArchiveEntry(int igdbId)
        {
            IgdbId = igdbId;
        }

        public void SetArchiveDate(DateTime? date = null)
        {
            Archived = date ?? DateTime.Now;
        }

        public int Id { get; set; }
        public int IgdbId { get; set; }
        public DateTime Archived { get; set; }
    }
}
