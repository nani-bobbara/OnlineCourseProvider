using Microsoft.EntityFrameworkCore;
using OnlineCourseProvider.Models;
using OnlineCourseProvider.Services;
using System.Reflection.Emit;

namespace OnlineCourseProvider.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<UserLessonProgress> UserLessonProgresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLessonProgress>()
                .HasKey(ulp => new { ulp.UserId, ulp.LessonId });

            modelBuilder.Entity<UserLessonProgress>()
                .HasOne(ulp => ulp.User)
                .WithMany(u => u.UserLessonProgresses)
                .HasForeignKey(ulp => ulp.UserId);

            modelBuilder.Entity<UserLessonProgress>()
                .HasOne(ulp => ulp.Lesson)
                .WithMany(l => l.UserLessonProgresses)
                .HasForeignKey(ulp => ulp.LessonId);          

            modelBuilder.Entity<Section>()
                .HasIndex(s => s.CourseId);

            modelBuilder.Entity<Lesson>()
                .HasIndex(l => l.SectionId);

            FakeDataService.SeedData(modelBuilder);
        }
    }


}
