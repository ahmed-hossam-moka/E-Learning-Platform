using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos.Quizs
{
    public class SubmitQuizDto
    {
        public string StudentId { get; set; }
        public int QuizId { get; set; }
        public List<StudentAnswerDto> Answers { get; set; }
    }

    public class StudentAnswerDto
    {
        public int QuestionId { get; set; }
        public int SelectedChoiceId { get; set; }
    }
}
