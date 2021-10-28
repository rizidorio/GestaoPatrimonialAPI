using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GestaoPatrimonial.Application.FilterModels.Paginated
{
    public class PaginatedModel<T> : ActionResult
    {
        private const int DEFAULT_PAGE_SIZE = 10;
        private const int MAX_PAGE_SIZE = 50;

        public int TotalItems { get; private set; }
        public int Limit { get; private set; }
        public int Page { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Objects { get; set; }

        internal PaginatedModel(int pageNumber, int pageSize = DEFAULT_PAGE_SIZE)
        {
            Limit = pageSize;
            Page = pageNumber;

            if (Limit < 0 || Limit > MAX_PAGE_SIZE)
            {
                Limit = DEFAULT_PAGE_SIZE;
            }

            if (Page < 0)
            {
                Page = 0;
            }
        }

        internal PaginatedModel<T> Paginate(IEnumerable<T> list)
        {
            TotalItems = list.Count();

            TotalPages = (int)Math.Ceiling((decimal)TotalItems / (decimal)Limit);

            if (Limit > TotalPages)
            {
                Limit = TotalItems;
                Page = Limit > 10 ? Limit - 9 : 0;
            }

            int skip = Page * Limit;

            if (skip + Limit > TotalPages)
            {
                skip = TotalPages - Limit;
                Page = TotalPages / Limit - 1;
            }

            Objects = list.Skip(skip).Take(Limit).ToList();

            return this;
        }
    }
}
