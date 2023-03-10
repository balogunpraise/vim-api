using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vim.Core.Application
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => TotalPages > CurrentPage;


        public PagedList(List<T> items, int count, int pageSize, int pageNumber)
        {
            TotalCount = count;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            CurrentPage = pageNumber;
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageSize, pageNumber);
        }
    }
}
