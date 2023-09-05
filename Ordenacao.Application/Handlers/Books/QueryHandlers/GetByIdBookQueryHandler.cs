using AutoMapper;
using MediatR;
using Ordenacao.Application.Commons.Handlers;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Queries;
using Ordenacao.Application.Handlers.Books.Responses;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Interfaces.Data.Repositories;

namespace Ordenacao.Application.Handlers.Books.QueryHandlers
{
    public class GetByIdBookQueryHandler : Handler, IRequestHandler<GetByIdBookQuery, Response<BookResponse>>
    {
        private readonly IBookRepository _bookRepository;

        public GetByIdBookQueryHandler(IUnitOfWork uow, IMapper mapper, IBookRepository bookRepository)
            : base(uow, mapper)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response<BookResponse>> Handle(GetByIdBookQuery query, CancellationToken cancellationToken)
        {
            var todo = await _bookRepository.GetById(query.Id, cancellationToken);

            var response = _mapper.Map<BookResponse>(todo);

            return Success(response);
        }
    }
}
