using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity? GetById(object id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
