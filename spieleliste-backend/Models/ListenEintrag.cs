using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Models
{
    public class ListenEintrag
    {
        [Obsolete("Ef Core only")]
        public ListenEintrag()
        {

        }

        public ListenEintrag(int spielId)
        {
            SpielId = spielId;
        }

        public int SpielId { get; private set; }
    }
}
