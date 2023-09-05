

using Ordenacao.Domain.Interfaces.Data.Repositories;
using Ordenacao.Domain.Models;
using Ordenacao.Infra.Data.DataContexts;
using Ordenacao.Infra.Data.Repositories.Base;

namespace Ordenacao.Infra.Data.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
