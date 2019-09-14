using System.Collections.Generic;
using System.Threading.Tasks;
using spieleliste_backend.Models;

namespace spieleliste_backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User entry);
        Task<User> Get(int id);
        Task<IEnumerable<User>> List();
        Task Remove(User entry);
        Task<User> Update(User entry);
    }
}