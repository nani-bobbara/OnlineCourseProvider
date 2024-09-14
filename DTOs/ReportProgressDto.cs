namespace OnlineCourseProvider.DTOs
{
    public class ReportProgressDto
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public double PercentageWatched { get; set; }
    }
}
