using System.Globalization;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class CreateQuizResultDto
    {
        public string StudentId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public bool Ispassed { get; set; }
    }
}
