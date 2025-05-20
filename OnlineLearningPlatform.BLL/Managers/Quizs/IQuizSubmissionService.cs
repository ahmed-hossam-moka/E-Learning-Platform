using OnlineLearningPlatform.BLL.Dtos.Quizs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers.Quizs
{
    public interface IQuizSubmissionService
    {
        Task<QuizResultDto> SubmitQuizAsync(SubmitQuizDto dto);
    }
}
