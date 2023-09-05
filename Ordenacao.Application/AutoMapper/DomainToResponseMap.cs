using AutoMapper;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Responses;
using Ordenacao.Domain.Models;
using Ordenacao.Infra.CrossCutting.Commons.Extensions;

namespace Ordenacao.Application.AutoMapper
{
    public class DomainToResponseMap : Profile
    {
        public DomainToResponseMap()
        {
            CreateMap<Book, BookResponse>();

            CreateMap<Pagination<Book>, PagedListResponse<BookResponse>>();
        }
    }
}
