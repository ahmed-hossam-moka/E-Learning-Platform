namespace OnlineLearningPlatform.DAL.Models
{
    public class Quiz : ISoftDeletable
    {
        public int QuizId { get; set; }
        public int? CourseId { get; set; }
        public string? Title { get; set; }
        public int? PassingScore { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public Course? Course { get; set; }


        public ICollection<Question>? Questions { get; set; } = new List<Question>();
        public ICollection<QuizResult>? QuizResults { get; set; }
    }
}
