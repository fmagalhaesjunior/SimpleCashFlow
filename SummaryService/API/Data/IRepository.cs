using System.Linq.Expressions;

namespace API.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
    }
}