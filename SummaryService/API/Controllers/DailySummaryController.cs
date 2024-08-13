using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySummaryController : ControllerBase
    {
        private readonly ILogger<DailySummaryController> _logger;
        private readonly ISummaryService _dailySummaryService;
        public DailySummaryController(ILogger<DailySummaryController> logger, ISummaryService dailySummaryService)
        {
            _logger = logger;
            _dailySummaryService = dailySummaryService;
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetDailySummary(DateTime date)
        {
            try
            {
                var summary = await _dailySummaryService.GetDailySummary(date);
                if (summary == null)
                {
                    return NotFound();
                }
                return Ok(summary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado: {Message}", ex.Message);
                return StatusCode(500, new { ex.Message });
            }
            
        }
    }
}
