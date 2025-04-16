namespace OnlineLearningPlatform.DAL.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
