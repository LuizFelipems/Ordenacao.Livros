using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions;
using Ordenacao.Application.Commons.Queries;

namespace Ordenacao.Application.Handlers.Books.Queries.Parameters
{
    public record GetAllBooksPaginatedParameters : QueryParameters, ICustomQueryable
    {
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string? Title { get; set; }
        
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string? AuthorName { get; set; }
    }
}
