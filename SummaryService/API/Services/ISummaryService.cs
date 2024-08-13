using API.Entities;

namespace API.Services
{
    public interface ISummaryService
    {
        public Task<DailySummary> GetDailySummary(DateTime date);
    }
}
