using System.Threading.Tasks;
using spieleliste_backend.Repositories;

namespace spieleliste_backend.Data
{
    public interface IUnitOfWork
    {
        IListenEintragRepository ListenEintraege { get; set; }
        IUserEntryRepository UserEntries { get; set; }
        IUserRepository Users { get; set; }

        Task Complete();
    }
}
