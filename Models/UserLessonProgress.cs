using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseProvider.Models
{
    public class UserLessonProgress
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key, Column(Order = 1)]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [Range(0, 100)]
        public double PercentageWatched { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
