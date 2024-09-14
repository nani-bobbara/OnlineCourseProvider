namespace OnlineCourseProvider.DTOs
{
    public class CourseDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SectionDto> Sections { get; set; }
    }
}
