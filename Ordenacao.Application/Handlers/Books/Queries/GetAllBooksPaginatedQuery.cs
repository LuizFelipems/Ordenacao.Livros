using Ordenacao.Application.Commons.Queries;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Queries.Parameters;
using Ordenacao.Application.Handlers.Books.Responses;

namespace Ordenacao.Application.Handlers.Books.Queries
{
    public record GetAllBooksPaginatedQuery : Query<PagedListResponse<BookResponse>>
    {
        public GetAllBooksPaginatedParameters Parameters { get; set; }

        public GetAllBooksPaginatedQuery() { }

        public GetAllBooksPaginatedQuery(GetAllBooksPaginatedParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
