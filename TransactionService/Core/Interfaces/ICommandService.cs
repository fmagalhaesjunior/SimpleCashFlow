using FluentValidation;

namespace Core.Interfaces
{
    public interface ICommandService<TEntity> where TEntity : class
    {
        void Add<TInputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class;
        void Remove(TEntity entity);

        void Update<TInputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class;
    }
}
