using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IQueryRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(object id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
    }
}
