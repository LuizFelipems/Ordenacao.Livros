using AutoMapper;
using MediatR;
using Ordenacao.Application.Commons.Handlers;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Commands;
using Ordenacao.Application.Handlers.Books.Responses;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Interfaces.Data.Repositories;

namespace Ordenacao.Application.Handlers.Books.CommandHandlers
{
    public class UpdateBookCommandHandler : Handler, IRequestHandler<UpdateBookCommand, Response<BookResponse>>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IUnitOfWork uow, IMapper mapper, IBookRepository bookRepository)
            : base(uow, mapper)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response<BookResponse>> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(command.Id, cancellationToken);
            if (book is null)
                return Fail<BookResponse>();

            _mapper.Map(command, book);
            _bookRepository.Update(book);

            await CommitAsync(cancellationToken);
            var response = _mapper.Map<BookResponse>(book);
            return Success(response);
        }
    }
}
