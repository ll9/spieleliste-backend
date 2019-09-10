using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class Spieleliste
    {
        public ICollection<int> SpielIds { get; set; }
    }
}
