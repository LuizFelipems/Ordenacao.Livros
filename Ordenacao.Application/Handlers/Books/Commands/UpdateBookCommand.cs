using Ordenacao.Application.Commons.Commands;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Responses;
using System.Text.Json.Serialization;

namespace Ordenacao.Application.Handlers.Books.Commands
{
    public record UpdateBookCommand : CommandRequest<Response<BookResponse>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int EditionYear { get; set; }

        public UpdateBookCommand AssignId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
