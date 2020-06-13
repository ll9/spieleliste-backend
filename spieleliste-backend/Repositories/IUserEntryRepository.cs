using spieleliste_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace spieleliste_backend.Repositories
{
    public interface IUserEntryRepository
    {
        Task<UserEntry> Add(UserEntry entry);

        Task<UserEntry> Get(int userId, int igdbId);

        Task<UserEntry> Get(int id);

        Task<IEnumerable<UserEntry>> List();

        Task<IEnumerable<UserEntry>> List(Expression<Func<UserEntry, bool>> predicate);

        Task<IEnumerable<UserEntry>> ListByUser(int userId);

        Task Remove(UserEntry entry);

        Task<UserEntry> Update(UserEntry entry);
    }
}