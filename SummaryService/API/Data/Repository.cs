using System.Linq.Expressions;

namespace API.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SummaryContext _summaryContext;
        public Repository(SummaryContext summaryContext)
        {
            _summaryContext = summaryContext;
        }

        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _summaryContext.Set<TEntity>().Where(predicate);
        }
    }
}
