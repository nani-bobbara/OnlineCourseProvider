using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseProvider.DTOs;
using OnlineCourseProvider.Services;

namespace OnlineCourseProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;
        private readonly ILogger<ProgressController> _logger;

        public ProgressController(IProgressService progressService, ILogger<ProgressController> logger)
        {
            _progressService = progressService;
            _logger = logger;
        }

        // Endpoint to log the lesson watch progress
        
        [HttpPost()]
        public async Task<IActionResult> LogLessonProgress([FromBody] ReportProgressDto dto)
        {
            await _progressService.ReportProgressAsync(dto.UserId, dto.LessonId, dto.PercentageWatched);
            return NoContent();
        }
    }
}
