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

    }
}
