using Moq;
using Ordenacao.Domain.Interfaces.Services;
using Ordenacao.Domain.Models;

namespace Shared.Mocks.Services
{
    public class BooksOrdererServiceMockBuilder
    {
        private readonly Mock<IBooksOrdererService> _booksOrdererService;

        private BooksOrdererServiceMockBuilder()
        {
            _booksOrdererService = new Mock<IBooksOrdererService>();
        }

        public static BooksOrdererServiceMockBuilder Instance() => new BooksOrdererServiceMockBuilder();

        public IBooksOrdererService Build() => _booksOrdererService.Object;

        public BooksOrdererServiceMockBuilder Orderer(List<Book> booksReturn)
        {
            _booksOrdererService.Setup(x => x.Orderer(It.IsAny<List<Book>>()))
                .Returns(booksReturn);

            return this;
        }
        
        public BooksOrdererServiceMockBuilder VerifyOrderer()
        {
            _booksOrdererService.Verify(x => x.Orderer(It.IsAny<List<Book>>()), Times.Once);

            return this;
        }
    }
}
