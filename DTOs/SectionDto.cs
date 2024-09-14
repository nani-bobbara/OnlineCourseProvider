namespace OnlineCourseProvider.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }
}
