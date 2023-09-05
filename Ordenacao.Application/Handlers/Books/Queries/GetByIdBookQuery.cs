using Ordenacao.Application.Commons.Queries;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Responses;

namespace Ordenacao.Application.Handlers.Books.Queries
{
    public record GetByIdBookQuery : Query<Response<BookResponse>>
    {
        public Guid Id { get; set; }

        public GetByIdBookQuery(Guid id)
        {
            Id = id;
        }
    }
}
