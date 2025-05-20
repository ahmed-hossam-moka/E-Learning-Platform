using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Models
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }
        public bool IsCorrect { get; set; }

        public int QuizResultId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedAnswerId { get; set; }


        public Question Question { get; set; }
        public AnswerChoice SelectedAnswer { get; set; }
        public QuizResult QuizResult { get; set; }

    }
}
