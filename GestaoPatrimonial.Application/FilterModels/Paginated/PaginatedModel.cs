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
        public int CurrentPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Objects { get; set; }

        internal PaginatedModel(int pageNumber, int pageSize = DEFAULT_PAGE_SIZE)
        {
            Limit = pageSize;
            CurrentPage = pageNumber;

            if (Limit < 0 || Limit > MAX_PAGE_SIZE)
            {
                Limit = DEFAULT_PAGE_SIZE;
            }

            if (CurrentPage < 0)
            {
                CurrentPage = 1;
            }
        }

        internal PaginatedModel<T> Paginate(IEnumerable<T> list)
        {
            TotalItems = list.Count();

            TotalPages = (int)Math.Ceiling(TotalItems / (decimal)Limit);
            StartPage = CurrentPage - 2;
            EndPage = CurrentPage + 1;

            if (StartPage <= 0)
            {
                EndPage -= (StartPage - 1);
                StartPage = 1;
            }

            if (EndPage > TotalPages)
            {
                EndPage = TotalPages;

                if (EndPage > Limit)
                {
                    StartPage = EndPage - 9;
                }
            }

            int skip = (CurrentPage - 1) * Limit;

            Objects = list.Skip(skip).Take(Limit).ToList();

            return this;
        }
    }
}
