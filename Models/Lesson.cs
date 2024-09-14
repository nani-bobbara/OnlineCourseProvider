using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseProvider.Models
{
    public class Lesson : BaseEntity
    {
        [Required]
        public string VideoUrl { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }


        public ICollection<UserLessonProgress> UserLessonProgresses { get; set; }
    }
}
