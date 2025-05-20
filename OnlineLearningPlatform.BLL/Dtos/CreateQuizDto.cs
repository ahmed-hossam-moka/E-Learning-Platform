namespace OnlineLearningPlatform.BLL.Dtos
{
    public class CreateQuizDto
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int? PassingScore { get; set; }
        public List<CreateQuestionDto>? Questions { get; set; }
    }

    public class CreateQuestionDto
    {
        public int QuizId { get; set; }
        public string? Text { get; set; }
        public List<CreateChoiceDto>? Choices { get; set; }
    }

    public class CreateChoiceDto
    {
        public string? Text { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
