using Core.Interfaces;
using Infrastructure.Data.Contexts;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
    {
        private readonly PostgreSqlContext _context;
        public QueryRepository(PostgreSqlContext context)
        {
            _context = context;
        }
        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity? GetById(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
