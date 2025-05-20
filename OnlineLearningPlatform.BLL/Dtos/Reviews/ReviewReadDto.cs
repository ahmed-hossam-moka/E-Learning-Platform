namespace OnlineLearningPlatform.BLL.Dtos.Reviews
{
    public class ReviewReadDto
    {
        public int ReviewId { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}