using AutoMapper;
using MediatR;
using Ordenacao.Application.Commons.Handlers;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Commands;
using Ordenacao.Application.Handlers.Books.Responses;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Interfaces.Services;
using Ordenacao.Domain.Models;

namespace Ordenacao.Application.Handlers.Books.CommandHandlers
{
    /// <summary>
    /// CommandHandler responsável por acionar o serviço de Ordenação de livros
    /// </summary>
    public class OrdinationBooksCommandHandler : Handler, IRequestHandler<OrdinationBooksCommand, Response<List<BookResponse>>>
    {
        private readonly IBooksOrdererService _booksOrdererService;

        public OrdinationBooksCommandHandler(IUnitOfWork uow, IMapper mapper, IBooksOrdererService booksOrderer)
            : base(uow, mapper)
        {
            _booksOrdererService = booksOrderer;
        }

        public async Task<Response<List<BookResponse>>> Handle(OrdinationBooksCommand command, CancellationToken cancellationToken)
        {
            var books = _mapper.Map<List<Book>>(command.Books);

            var orderedBooks = _booksOrdererService.Orderer(books);

            var response = _mapper.Map<List<BookResponse>>(orderedBooks);
            return Success(response);
        }
    }
}
