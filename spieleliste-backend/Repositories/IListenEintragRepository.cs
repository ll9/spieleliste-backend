using System.Collections.Generic;
using System.Threading.Tasks;
using spieleliste_backend.Models;

namespace spieleliste_backend.Repositories
{
    public interface IListenEintragRepository
    {
        Task<ListEntry> Add(ListEntry entry);
        Task<ListEntry> Get(int id);
        Task<IEnumerable<ListEntry>> List();
        Task Remove(ListEntry entry);
    }
}