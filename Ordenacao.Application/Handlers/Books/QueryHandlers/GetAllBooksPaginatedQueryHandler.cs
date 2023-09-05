using AspNetCore.IQueryable.Extensions.Filter;
using AutoMapper;
using MediatR;
using Ordenacao.Application.Commons.Handlers;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Queries;
using Ordenacao.Application.Handlers.Books.Responses;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Interfaces.Data.Repositories;
using Ordenacao.Infra.CrossCutting.Commons.Extensions;

namespace Ordenacao.Application.Handlers.Books.QueryHandlers
{
    public class GetAllBooksPaginatedQueryHandler : Handler, IRequestHandler<GetAllBooksPaginatedQuery, PagedListResponse<BookResponse>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksPaginatedQueryHandler(IUnitOfWork uow, IMapper mapper, IBookRepository bookRepository)
            : base(uow, mapper)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PagedListResponse<BookResponse>> Handle(GetAllBooksPaginatedQuery query, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.Include()
                                       .Filter(query.Parameters)
                                       .PaginateAsync(query.Parameters.PageNumber, query.Parameters.PageSize, cancellationToken);

            return _mapper.Map<PagedListResponse<BookResponse>>(books);
        }
    }
}
