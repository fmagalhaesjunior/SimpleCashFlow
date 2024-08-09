using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IQueryService<TEntity> where TEntity : class
    {
        TOutputModel GetById<TOutputModel>(object id) 
            where TOutputModel : class;

        IEnumerable<TOutputModel> GetAll<TOutputModel>() 
            where TOutputModel : class;

        IEnumerable<TOutputModel> Select<TOutputModel>(Expression<Func<TEntity, bool>> predicate)
            where TOutputModel : class;
    }
}
