namespace OnlineLearningPlatform.BLL.Dtos.Quizs
{
    public class QuizResultDto
    {
        public int QuizResultId { get; set; }
        public string StudentId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public bool Ispassed { get; set; }
        public DateTime TakenAt { get; set; }

    }
}
