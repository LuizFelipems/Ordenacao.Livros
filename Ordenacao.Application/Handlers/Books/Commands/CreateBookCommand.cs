using Ordenacao.Application.Commons.Commands;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Responses;

namespace Ordenacao.Application.Handlers.Books.Commands
{
    public record CreateBookCommand : CommandRequest<Response<BookResponse>>
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int EditionYear { get; set; }
    }
}
