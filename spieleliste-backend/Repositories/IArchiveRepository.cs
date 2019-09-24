using System.Collections.Generic;
using System.Threading.Tasks;
using spieleliste_backend.Models;

namespace spieleliste_backend.Repositories
{
    public interface IArchiveRepository
    {
        Task Delete(ArchiveEntry archiveEntry);
        Task<ArchiveEntry> Get(int id);
        Task<IEnumerable<ArchiveEntry>> List();
    }
}