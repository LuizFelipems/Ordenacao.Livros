﻿using AspNetCore.IQueryable.Extensions.Attributes;

namespace Ordenacao.Application.Commons.Queries
{
    public record QueryParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

        public string SortBy { get; set; }
    }
}
