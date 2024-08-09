using Core.Interfaces;
using Infrastructure.Data.Contexts;

namespace Infrastructure.Data.Repositories
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        private readonly PostgreSqlContext _context;

        public CommandRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
    }
}
