using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserEintrag> UserEintraege { get; set; }
    }
}
