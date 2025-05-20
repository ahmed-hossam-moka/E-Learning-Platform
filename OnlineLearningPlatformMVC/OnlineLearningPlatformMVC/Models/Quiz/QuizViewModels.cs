namespace OnlineLearningPlatform.MVC.Models.Quiz
{
    public class QuizViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PassingScore { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CourseId { get; set; }
    }

    public class CreateQuizViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int PassingScore { get; set; }
        public List<CreateQuestionViewModel> Questions { get; set; } = new List<CreateQuestionViewModel>();
    }

    public class CreateQuestionViewModel
    {
        public string Text { get; set; }
        public List<CreateChoiceViewModel> Choices { get; set; } = new List<CreateChoiceViewModel>();
    }

    public class CreateChoiceViewModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public List<ChoiceViewModel> Choices { get; set; }
    }

    public class ChoiceViewModel
    {
        public int ChoiceId { get; set; }
        public string Text { get; set; }
    }

    public class SubmitQuizViewModel
    {
        public string StudentId { get; set; } 
        public int QuizId { get; set; }
        public List<StudentAnswerViewModel> Answers { get; set; }
    }

    public class StudentAnswerViewModel
    {
        public int QuestionId { get; set; }
        public int SelectedChoiceId { get; set; }
    }

    public class QuizResultViewModel
    {
        public int QuizResultId { get; set; }
        public string StudentId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public bool IsPassed { get; set; }
        public DateTime TakenAt { get; set; }
    }
}