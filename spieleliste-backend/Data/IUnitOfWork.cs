using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Models;

namespace spieleliste_backend.Data
{
    public interface IUnitOfWork
    {
        DbSet<ListenEintrag> ListenEintraege { get; set; }

        Task Complete();
    }
}