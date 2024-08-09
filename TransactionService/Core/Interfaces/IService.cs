using FluentValidation;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add<TInputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class;

        TOutputModel GetById<TOutputModel>(object id)
            where TOutputModel : class;

        IEnumerable<TOutputModel> GetAll<TOutputModel>()
            where TOutputModel : class;

        IEnumerable<TOutputModel> Select<TOutputModel>(Expression<Func<TEntity, bool>> predicate)
            where TOutputModel : class;

        void Remove(TEntity entity);

        void Update<TInputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class;
    }
}
