using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public abstract class AbstractController<TController> : ControllerBase 
        where TController : AbstractController<TController>
    {
        private readonly ILogger<TController> _logger;
        protected AbstractController(ILogger<TController> logger)
        {
            _logger = logger;
        }
        protected IActionResult Execute(Func<object> func)
        {
            _logger.LogInformation("Iniciando execução de operação.");
            try
			{
                var result = func();
                _logger.LogInformation("Operação concluída com sucesso.");
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Objeto não encontrado: {Message}", ex.Message);
                return NotFound(new { ex.Message });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Erro de domínio: {Message}", ex.Message);
                return UnprocessableEntity(new { ex.Message });
            }
            catch (FluentValidation.ValidationException ex)
            {
                _logger.LogWarning(ex, "Erro de validação: {Message}", ex.Message);
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
			{
                _logger.LogError(ex, "Erro inesperado: {Message}", ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
