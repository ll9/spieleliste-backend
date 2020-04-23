using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spieleliste_backend.Helper
{
    public class PagedList<T> : List<T>
    {
        private PagedList(List<T> items)
        {
            AddRange(items);
        }

        public static async Task<PagedList<T>> Create(IQueryable<T> query, ResourceParameters resource)
        {
            var items = await query
                .Skip(resource.SkipCount)
                .Take(resource.PageSize)
                .ToListAsync();

            return new PagedList<T>(items);
        }
    }
}