using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseProvider.Models
{
    public class User : BaseEntity
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<UserLessonProgress> UserLessonProgresses { get; set; }
    }
}
