using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Models;
using spieleliste_backend.Repositories;

namespace spieleliste_backend.Data
{
    public interface IUnitOfWork
    {
        IListenEintragRepository ListenEintraege { get; set; }

        Task Complete();
    }
}