using spieleliste_backend.Dtos;
using spieleliste_backend.Helper;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace spieleliste_backend.Repositories
{
    public interface IArchiveRepository
    {
        Task<ArchiveEntry> Create(ArchiveEntry archiveEntry);

        Task Delete(ArchiveEntry archiveEntry);

        Task<ArchiveEntry> Get(int id);

        Task<IEnumerable<ArchiveEntry>> List();

        Task<PagedList<ArchiveEntry>> List(ResourceParameters resourceParameters);
    }
}