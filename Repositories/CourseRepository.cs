using Microsoft.EntityFrameworkCore;
using OnlineCourseProvider.Data;
using OnlineCourseProvider.Models;

namespace OnlineCourseProvider.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.Where(c => c.IsActive).Include(c => c.Sections).ThenInclude(s => s.Lessons).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(c => c.Sections).ThenInclude(s => s.Lessons).FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
        }

        public async Task AddAsync(Course entity)
        {
            await _context.Courses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course entity)
        {
            _context.Courses.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
