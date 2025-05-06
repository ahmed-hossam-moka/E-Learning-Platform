namespace OnlineLearningPlatform.DAL.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int PassingScore { get; set; } 
        public DateTime CreatedAt { get; set; }
        public Course Course { get; set; }
        public ICollection<QuizResult> QuizResults { get; set; }
    }
}
