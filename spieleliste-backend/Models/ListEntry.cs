using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class ListEntry
    {
        [Obsolete("Ef Core only")]
        public ListEntry()
        {

        }

        public ListEntry(int igdbId)
        {
            IgdbId = igdbId;
        }

        public int IgdbId { get; set; }
    }
}
