using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseProvider.DTOs;
using OnlineCourseProvider.Services;

namespace OnlineCourseProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService courseService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        // Endpoint to retrieve all courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDetailsDto>>> GetAllCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCoursesAsync();
                var courseDetailsList = courses.Select(course => new CourseDetailsDto
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    Sections = course.Sections.Select(s => new SectionDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Lessons = s.Lessons.Select(l => new LessonDto
                        {
                            Id = l.Id,
                            Name = l.Name,
                            VideoUrl = l.VideoUrl
                        }).ToList()
                    }).ToList()
                }).ToList();

                return Ok(courseDetailsList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all courses.");
                return StatusCode(500, "Internal server error");
            }
        }

        // Endpoint to retrieve detailed information about courses, sections, and lessons
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailsDto>> GetCourseDetails(int id)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id);
                if (course == null)
                {
                    return NotFound();
                }

                var courseDetails = new CourseDetailsDto
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    Sections = course.Sections.Select(s => new SectionDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Lessons = s.Lessons.Select(l => new LessonDto
                        {
                            Id = l.Id,
                            Name = l.Name,
                            VideoUrl = l.VideoUrl
                        }).ToList()
                    }).ToList()
                };

                return Ok(courseDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving course details.");
                return StatusCode(500, "Internal server error");
            }
        }

        /*
        [HttpPost("ReportProgress")]
        public async Task<IActionResult> LogLessonProgress([FromBody] ReportProgressDto dto)
        {
            await _courseService.ReportProgressAsync(dto.UserId, dto.LessonId, dto.PercentageWatched);
            return NoContent();
        }
        */
    }
}
