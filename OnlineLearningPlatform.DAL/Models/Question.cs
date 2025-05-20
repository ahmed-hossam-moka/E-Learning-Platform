using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Models
{
    public class Question
    {
        public int QuestionId { get; set; }          // Primary Key
        public string? Text { get; set; }

        public int? QuizId { get; set; }              // Foreign Key
        public Quiz? Quiz { get; set; }

        public ICollection<AnswerChoice>? Choices { get; set; } = new List<AnswerChoice>();
    }
}
