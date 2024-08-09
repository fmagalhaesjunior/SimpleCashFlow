using AutoMapper;
using Core.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace Application.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;
        public Service(IMapper mapper, IRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add<TInputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _repository.Add(entity);
        }

        public IEnumerable<TOutputModel> GetAll<TOutputModel>()
            where TOutputModel : class
        {
            var entities = _repository.GetAll();
            var outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));
            return outputModels;
        }

        public TOutputModel GetById<TOutputModel>(object id)
            where TOutputModel : class
        {
            var entity = _repository.GetById(id);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        public void Remove(TEntity entity) =>
            _repository.Remove(entity);

        public void Update<TInputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _repository.Update(entity);
        }

        public IEnumerable<TOutputModel> Select<TOutputModel>(Expression<Func<TEntity, bool>> predicate)
            where TOutputModel : class
        {
            var entities = _repository.Select(predicate);
            var outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));
            return outputModels;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            ArgumentNullException.ThrowIfNull(obj);
            validator.ValidateAndThrow(obj);
        }
    }
}
