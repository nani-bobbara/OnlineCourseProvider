using Bogus;
using Microsoft.EntityFrameworkCore;
using OnlineCourseProvider.Models;

namespace OnlineCourseProvider.Services
{
    public static class FakeDataService
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed initial data
            var courses = GenerateCourses(100);
            modelBuilder.Entity<Course>().HasData(courses);

            var sections = GenerateSections(courses,500);
            modelBuilder.Entity<Section>().HasData(sections);

            var lessons = GenerateLessons(sections,2000);
            modelBuilder.Entity<Lesson>().HasData(lessons);

            var users = GenerateUsers(100);
            modelBuilder.Entity<User>().HasData(users);
        }

        private static List<Course> GenerateCourses(int maxCount)
        {
            return new Faker<Course>()
                .RuleFor(c => c.Id, f => f.Random.Int(0, int.MaxValue))
                .RuleFor(c => c.Name, f => f.Company.CatchPhrase())
                .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                .RuleFor(c => c.CreatedAt, f => DateTime.UtcNow)
                .RuleFor(c => c.UpdatedAt, f => DateTime.UtcNow)
                .Generate(maxCount);
        }

        private static List<Section> GenerateSections(List<Course> courses, int maxCount)
        {
            return new Faker<Section>()
                .RuleFor(s => s.Id, f => f.Random.Int(0, int.MaxValue))
                .RuleFor(s => s.CourseId, f => courses.ElementAt(f.Random.Int(0, courses.Count - 1)).Id)
                .RuleFor(s => s.Name, f => f.Lorem.Sentence())
                .RuleFor(c => c.CreatedAt, f => DateTime.UtcNow)
                .RuleFor(s => s.UpdatedAt, f => DateTime.UtcNow)
                .Generate(maxCount);
        }

        private static List<Lesson> GenerateLessons(List<Section> sections, int maxCount)
        {
            return new Faker<Lesson>()
                .RuleFor(l => l.Id, f => f.Random.Int(0, int.MaxValue))
                .RuleFor(l => l.SectionId, f => sections.ElementAt(f.Random.Int(0, sections.Count - 1)).Id)
                .RuleFor(l => l.Name, f => f.Lorem.Sentence())
                .RuleFor(l => l.VideoUrl, f => $"https://OnlineCourseProvider.com/lessons/{f.Random.Int(1, 1000)}.mp4")
                .RuleFor(c => c.CreatedAt, f => DateTime.UtcNow)
                .RuleFor(l => l.UpdatedAt, f => DateTime.UtcNow)
                .Generate(maxCount);
        }

        private static List<User> GenerateUsers(int maxCount)
        {
            return new Faker<User>()
                .RuleFor(u => u.Id, f => f.Random.Int(0, int.MaxValue))
                .RuleFor(u => u.Name, f => f.Name.FirstName() + "." + f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(c => c.CreatedAt, f => DateTime.UtcNow)
                .RuleFor(u => u.UpdatedAt, f => DateTime.UtcNow)
                .Generate(maxCount);
        }
    }
}
