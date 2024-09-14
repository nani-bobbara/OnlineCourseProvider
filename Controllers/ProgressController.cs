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
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;

        public ProgressController(ICourseService courseService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        // Endpoint to log the lesson watch progress
        
        [HttpPost()]
        public async Task<IActionResult> LogLessonProgress([FromBody] ReportProgressDto dto)
        {
            await _courseService.ReportProgressAsync(dto.UserId, dto.LessonId, dto.PercentageWatched);
            return NoContent();
        }
    }
}
