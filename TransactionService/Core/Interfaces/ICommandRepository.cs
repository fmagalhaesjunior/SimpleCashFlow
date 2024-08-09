namespace Core.Interfaces
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
