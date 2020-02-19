using System.Collections.Generic;

namespace spieleliste_backend.Extensions
{
    public static class IListExtension
    {
        public static int InsertAtOrLast<T>(this IList<T> list, int index, T item)
        {
            var indexOrLast = index > list.Count ? list.Count : index;

            list.Insert(indexOrLast, item);
            return indexOrLast;
        }
    }
}