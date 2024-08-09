using AutoMapper;
using Core.Interfaces;
using System.Linq.Expressions;

namespace Application.Services
{
    public class QueryService<TEntity> : IQueryService<TEntity> where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IQueryRepository<TEntity> _queryRepository;
        public QueryService(IMapper mapper, IQueryRepository<TEntity> queryRepository) 
        {
            _mapper = mapper;
            _queryRepository = queryRepository;
        }

        public IEnumerable<TOutputModel> Select<TOutputModel>(Expression<Func<TEntity, bool>> predicate) 
            where TOutputModel : class
        {
            var entities = _queryRepository.Select(predicate);
            var outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));
            return outputModels;
        }

        public IEnumerable<TOutputModel> GetAll<TOutputModel>() 
            where TOutputModel : class
        {
            var entities = _queryRepository.GetAll();
            var outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));
            return outputModels;
        }

        public TOutputModel GetById<TOutputModel>(object id) 
            where TOutputModel : class
        {
            var entity = _queryRepository.GetById(id);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
    }
}
