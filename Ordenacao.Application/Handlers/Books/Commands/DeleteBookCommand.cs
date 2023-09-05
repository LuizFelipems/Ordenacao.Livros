using FluentValidation.Results;
using Ordenacao.Application.Commons.Commands;
using System.Text.Json.Serialization;

namespace Ordenacao.Application.Handlers.Books.Commands
{
    public record DeleteBookCommand : CommandRequest<ValidationResult>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public DeleteBookCommand AssignId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
