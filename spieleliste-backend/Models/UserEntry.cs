using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class UserEntry
    {
        [Obsolete("Ef Core only")]
        public UserEntry()
        {

        }

        public UserEntry(int userId, int listEntryId)
        {
            UserId = userId;
            ListEntryId = listEntryId;
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int ListEntryId { get; set; }
        public ListEntry ListEntry { get; set; }
        public int Index { get; set; }
    }
}
