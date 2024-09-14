using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseProvider.Models
{
    public class Course : BaseEntity
    {
        [MaxLength(1000)]
        public string Description { get; set; }
        
        public bool IsActive { get; set; } = true;

        public ICollection<Section> Sections { get; set; }
    }
}
