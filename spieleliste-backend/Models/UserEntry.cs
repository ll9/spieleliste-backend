using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class UserEntry
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int ListenEintragId { get; set; }
        public ListEntry ListEntry { get; set; }
    }
}
