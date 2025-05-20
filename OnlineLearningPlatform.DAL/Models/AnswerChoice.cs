using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Models
{
    public class AnswerChoice
    {
        public int AnswerChoiceId { get; set; }      // Primary Key
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }          // Foreign Key
        public Question Question { get; set; }
    }
}
