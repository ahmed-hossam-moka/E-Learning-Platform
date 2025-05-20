namespace OnlineLearningPlatform.BLL.Dtos.Reviews
{
    public class ReviewAddDto
    {
        public int ReviewId { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}