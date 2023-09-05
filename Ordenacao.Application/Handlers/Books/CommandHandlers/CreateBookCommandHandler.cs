using AutoMapper;
using MediatR;
using Ordenacao.Application.Commons.Handlers;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Commands;
using Ordenacao.Application.Handlers.Books.Responses;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Interfaces.Data.Repositories;
using Ordenacao.Domain.Models;

namespace Ordenacao.Application.Handlers.Books.CommandHandlers
{
    public class CreateBookCommandHandler : Handler, IRequestHandler<CreateBookCommand, Response<BookResponse>>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IUnitOfWork uow, IMapper mapper, IBookRepository bookRepository)
            : base(uow, mapper)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response<BookResponse>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(command);
            if (!await IsValidAsync(book))
                return Fail<BookResponse>();

            await _bookRepository.Add(book, cancellationToken);

            await CommitAsync(cancellationToken);
            var response = _mapper.Map<BookResponse>(book);
            return Success(response);
        }
    }
}
