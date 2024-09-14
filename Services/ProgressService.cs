using Microsoft.AspNetCore.Cors.Infrastructure;
using OnlineCourseProvider.Data;
using OnlineCourseProvider.Models;
using OnlineCourseProvider.Repositories;

namespace OnlineCourseProvider.Services
{
    public class ProgressService : IProgressService
    {
        private readonly IRepository<UserLessonProgress> _progressRepository;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CourseService> _logger;


        public ProgressService(IRepository<UserLessonProgress> progressRepository, ApplicationDbContext context, ILogger<CourseService> logger)
        {
            _progressRepository = progressRepository;
            _context = context;
            _logger = logger;
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
