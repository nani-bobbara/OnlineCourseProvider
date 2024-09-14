using Microsoft.EntityFrameworkCore;
using OnlineCourseProvider.Data;
using OnlineCourseProvider.Models;

namespace OnlineCourseProvider.Repositories
{
    public class ProgressRepository : IRepository<UserLessonProgress>
    {
        private readonly ApplicationDbContext _context;

        public ProgressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserLessonProgress>> GetAllAsync()
        {
            return await _context.UserLessonProgresses.ToListAsync();
        }

        public async Task<UserLessonProgress> GetByIdAsync(int id)
        {
            return await _context.UserLessonProgresses.FindAsync(id);
        }

        public async Task AddAsync(UserLessonProgress entity)
        {
            await _context.UserLessonProgresses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserLessonProgress entity)
        {
            _context.UserLessonProgresses.Update(entity);
            await _context.SaveChangesAsync();
        }

    }

}
