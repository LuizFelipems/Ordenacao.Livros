using AutoMapper;
using Ordenacao.Application.Handlers.Books.Commands;
using Ordenacao.Domain.Models;

namespace Ordenacao.Application.AutoMapper
{
    public class RequestToDomainMap : Profile
    {
        public RequestToDomainMap()
        {
            CreateMap<BooksCommand, Book>();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
        }
    }
}
