using OnlineCourseProvider.Models;

namespace OnlineCourseProvider.Services
{
    public interface IProgressService
    {
        Task ReportProgressAsync(int userId, int lessonId, double percentageWatched);
    }
}
