using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseProvider.Models
{
    public class Section : BaseEntity
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
