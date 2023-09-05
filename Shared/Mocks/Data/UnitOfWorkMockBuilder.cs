using Moq;
using Ordenacao.Domain.Interfaces.Data;

namespace Shared.Mocks.Data
{
    public class UnitOfWorkMockBuilder
    {
        private readonly Mock<IUnitOfWork> _uow;

        private UnitOfWorkMockBuilder()
        {
            _uow = new Mock<IUnitOfWork>();

            _uow.Setup(u => u.HasChanges()).Returns(true);
            _uow.Setup(u => u.SaveAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        }

        public static UnitOfWorkMockBuilder Instance() => new UnitOfWorkMockBuilder();

        public IUnitOfWork Build() => _uow.Object;
    }
}
