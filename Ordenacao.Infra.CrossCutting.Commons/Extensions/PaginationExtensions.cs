using Microsoft.EntityFrameworkCore;

namespace Ordenacao.Infra.CrossCutting.Commons.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<Pagination<T>> PaginateAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var totalRecords = await query.CountAsync(cancellationToken);

            if (pageNumber > 0 && pageSize > 0)
                query = query.Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize);

            return new Pagination<T>(await query.ToListAsync(cancellationToken), pageNumber, pageSize, totalRecords);
        }
    }
}
