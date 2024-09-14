using Microsoft.AspNetCore.Cors.Infrastructure;
using OnlineCourseProvider.Data;
using OnlineCourseProvider.Models;
using OnlineCourseProvider.Repositories;

namespace OnlineCourseProvider.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CourseService> _logger;


        public CourseService(IRepository<Course> courseRepository, ApplicationDbContext context, ILogger<CourseService> logger)
        {
            _courseRepository = courseRepository;
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            try
            {
                return await _courseRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving all courses., {ex.InnerException}");
                throw;
            }
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            try
            {
                return await _courseRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the course with ID {id}., {ex.InnerException}");
                throw;
            }
        }

        public async Task ReportProgressAsync(int userId, int lessonId, double percentageWatched)
        {
            try
            {
                var progress = await _context.UserLessonProgresses.FindAsync(userId, lessonId);
                if (progress == null)
                {
                    progress = new UserLessonProgress
                    {
                        UserId = userId,
                        LessonId = lessonId,
                        PercentageWatched = percentageWatched
                    };
                    await _context.UserLessonProgresses.AddAsync(progress);
                }
                else
                {
                    progress.PercentageWatched = percentageWatched;
                    progress.UpdatedAt = DateTime.UtcNow;
                    _context.UserLessonProgresses.Update(progress);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while logging lesson progress., {ex.InnerException}");
                throw;
            }
        }
    }
}
