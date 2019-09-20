using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using spieleliste_backend.Models;

namespace spieleliste_backend.Repositories
{
    public interface IUserEntryRepository
    {
        Task<UserEntry> Add(UserEntry entry);
        Task<UserEntry> Get(int userId, int igdbId);
        Task<UserEntry> Get(int id);
        Task<IEnumerable<UserEntry>> List();
        Task<IEnumerable<UserEntry>> List(Predicate<UserEntry> predicate);
        Task<IEnumerable<UserEntry>> ListByUser(int userId);
        Task Remove(UserEntry entry);
        Task<UserEntry> Update(UserEntry entry);
    }
}