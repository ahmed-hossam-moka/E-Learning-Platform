namespace OnlineLearningPlatform.DAL.Models
{
    public class QuizResult
    {
        public int QuizResultId { get; set; }
        public string StudentId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }  
        public bool Ispassed { get; set; }  // computed coulum 
        public DateTime TakenAt { get; set; }
        public Student Student { get; set; }
        public Quiz Quiz { get; set; }
    }
}
