using System.Collections.Generic;
using System.Threading.Tasks;

namespace spieleliste_backend.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Add(T entry);

        Task<T> Get(int id);

        Task<IEnumerable<T>> List();

        Task Remove(T entry);

        Task<T> Update(T entry);
    }
}