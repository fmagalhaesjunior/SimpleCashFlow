using API.Data;
using API.Entities;

namespace API.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly IRepository<DailySummary> _repository;
        public SummaryService(IRepository<DailySummary> repository) 
        {
            _repository = repository;
        }
        public Task<DailySummary?> GetDailySummary(DateTime date)
        {
            var dailySummary = _repository.Select(d => d.Date == date).FirstOrDefault();
            return Task.FromResult(dailySummary);
        }
    }
}
