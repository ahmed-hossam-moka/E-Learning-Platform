using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos.Quizs
{
    public class CreateQuizDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int PassingScore { get; set; }
        public List<CreateQuestionDto> Questions { get; set; }  // الأسئلة مع الإجابات
    }

    public class CreateQuestionDto
    {
        public string Text { get; set; }
        public List<CreateChoiceDto> Choices { get; set; }
    }

    public class CreateChoiceDto
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

}
