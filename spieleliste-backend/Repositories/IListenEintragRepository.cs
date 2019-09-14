using System.Collections.Generic;
using System.Threading.Tasks;
using spieleliste_backend.Models;

namespace spieleliste_backend.Repositories
{
    public interface IListenEintragRepository
    {
        Task<ListenEintrag> Add(ListenEintrag entry);
        Task<ListenEintrag> Get(int id);
        Task<IEnumerable<ListenEintrag>> List();
        Task Remove(ListenEintrag entry);
    }
}