using Moq;
using Ordenacao.Domain.Interfaces.Data.Repositories;

namespace Shared.Mocks.Repositories
{
    public class BookRepositoryMockBuilder
    {
        private readonly Mock<IBookRepository> _bookRepository;

        private BookRepositoryMockBuilder()
        {
            _bookRepository = new Mock<IBookRepository>();
        }

        public static BookRepositoryMockBuilder Instance() => new BookRepositoryMockBuilder();

        public IBookRepository Build() => _bookRepository.Object;
    }
}
