using AutoMapper;
using Ordenacao.Application.Handlers.Books.CommandHandlers;
using Ordenacao.Domain.Interfaces.Data;
using Shared.Factory;
using Shared.Mocks.AutoMapper;
using Shared.Mocks.Data;
using Shared.Mocks.Services;

namespace Ordenacao.Application.Tests.Handlers.Books
{
    public class OrdinationBooksCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly BooksOrdererServiceMockBuilder _booksOrdererService;

        public OrdinationBooksCommandHandlerTests()
        {
            _mapper = MapperMockBuilder.Build();
            _uow = UnitOfWorkMockBuilder.Instance().Build();
            _booksOrdererService = BooksOrdererServiceMockBuilder.Instance();
        }

        private OrdinationBooksCommandHandler InitializeCommandHandler()
            => new(_uow, _mapper, _booksOrdererService.Build());
        
        [Fact]
        public async Task WhenRequestIsValid_ShouldSuccess()
        {
            #region Arrange
            var request = RequestFactory.GetOrdinationBooksCommand;
            var books = DomainFactory.GetBooks;

            _booksOrdererService.Orderer(books);

            var commandHandler = InitializeCommandHandler();
            #endregion

            #region Act
            var result = await commandHandler.Handle(request, default);
            #endregion

            #region Assert
            _booksOrdererService.VerifyOrderer();
            Assert.NotNull(result.Data);
            #endregion
        }

    }
}
