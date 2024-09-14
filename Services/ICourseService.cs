using OnlineCourseProvider.Models;

namespace OnlineCourseProvider.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
    }
}
