using Microsoft.EntityFrameworkCore;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Models.Base;
using Ordenacao.Infra.Data.DataContexts;
using System.Linq.Expressions;

namespace Ordenacao.Infra.Data.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity<T>
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> DbSet { get; init; }

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public virtual IQueryable<T> Include()
        {
            return DbSet;
        }

        public async Task<T> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(new object?[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(expression).ToListAsync(cancellationToken);
        }

        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public async Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);
        }

        public void Remove(T entity, CancellationToken cancellationToken = default)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            DbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
