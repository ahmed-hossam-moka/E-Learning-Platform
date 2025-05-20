using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos.Quizs
{
    public class QuestionWithChoicesDto
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public List<ChoiceDto> Choices { get; set; }
    }

    public class ChoiceDto
    {
        public int ChoiceId { get; set; }
        public string Text { get; set; }
    }

}
