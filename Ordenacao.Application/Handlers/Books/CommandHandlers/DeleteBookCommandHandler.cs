using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Ordenacao.Application.Commons.Handlers;
using Ordenacao.Application.Handlers.Books.Commands;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Interfaces.Data.Repositories;
using Ordenacao.Domain.Models;

namespace Ordenacao.Application.Handlers.Books.CommandHandlers
{
    public class DeleteBookCommandHandler : Handler, IRequestHandler<DeleteBookCommand, ValidationResult>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IUnitOfWork uow, IMapper mapper, IBookRepository bookRepository)
            : base(uow, mapper)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ValidationResult> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book { Id = command.Id };
            _bookRepository.Remove(book, cancellationToken);

            var result = await CommitAsync(cancellationToken);
            return result;
        }
    }
}
