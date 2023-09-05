using System.Linq.Expressions;

namespace Ordenacao.Domain.Interfaces.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Include();
        Task<T> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task Add(T entity, CancellationToken cancellationToken = default);
        Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        void Remove(T entity, CancellationToken cancellationToken = default);
        void RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        void Update(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
