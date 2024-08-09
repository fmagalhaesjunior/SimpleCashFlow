using AutoMapper;
using Core.Interfaces;
using FluentValidation;

namespace Application.Services
{
    public class CommandService<TEntity> : ICommandService<TEntity> where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository<TEntity> _commandRepository;

        public CommandService(IMapper mapper, ICommandRepository<TEntity> commandRepository)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
        }

        public void Add<TInputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _commandRepository.Add(entity);
        }

        public void Remove(TEntity entity) => 
            _commandRepository.Remove(entity);

        public void Update<TInputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _commandRepository.Update(entity);
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            ArgumentNullException.ThrowIfNull(obj);
            validator.ValidateAndThrow(obj);
        }
    }
}
