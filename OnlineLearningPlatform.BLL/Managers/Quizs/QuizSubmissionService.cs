//using OnlineLearningPlatform.BLL.Dtos.Quiz;
//using OnlineLearningPlatform.DAL.Models;
//using OnlineLearningPlatform.DAL.Repository.Quizs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OnlineLearningPlatform.BLL.Managers.Quizs
//{
//    public class QuizSubmissionService : IQuizSubmissionService
//    {
//        private readonly IQuizRepository _quizRepository;
//        private readonly IQuizResultRepository _quizResultRepository;
//        private readonly IQuestionRepository _questionRepository;
//        private readonly IStudentAnswerRepository _studentAnswerRepository;


//        public QuizSubmissionService(
//            IQuizRepository quizRepository,
//            IQuizResultRepository quizResultRepository,
//            IQuestionRepository questionRepository,
//            IStudentAnswerRepository studentAnswerRepository)
//        {
//            _quizRepository = quizRepository;
//            _quizResultRepository = quizResultRepository;
//            _questionRepository = questionRepository;
//            _studentAnswerRepository = studentAnswerRepository;
//        }

//        public async Task<QuizResultToReturnDto> SubmitQuizAsync(SubmitQuizDto dto)
//        {
//            var questions = await _questionRepository.GetQuestionsByQuizIdAsync(dto.QuizId);

//            int correctAnswers = 0;
//            foreach (var answer in dto.Answers)
//            {
//                var question = questions.FirstOrDefault(q => q.QuestionId == answer.QuestionId);
//                if (question == null) continue;

//                var correctChoice = question.Choices.FirstOrDefault(c => c.IsCorrect);
//                if (correctChoice != null && correctChoice.AnswerChoiceId == answer.SelectedChoiceId)
//                {
//                    correctAnswers++;
//                }
//            }

//            int score = (int)((double)correctAnswers / questions.Count * 100);
//            var quiz = await _quizRepository.GetByIdAsync(dto.QuizId);
//            bool isPassed = score >= quiz.PassingScore;

//            var quizResult = new QuizResult
//            {
//                StudentId = dto.StudentId,
//                QuizId = dto.QuizId,
//                Score = score,
//                Ispassed = isPassed,
//                TakenAt = DateTime.UtcNow
//            };

//            await _quizResultRepository.CreateAsync(quizResult);
//            await _quizResultRepository.CompleteAsync();

//            foreach (var answer in dto.Answers)
//            {
//                await _studentAnswerRepository.AddAsync(new StudentAnswer
//                {
//                    QuestionId = answer.QuestionId,
//                    StudentAnswerId = answer.SelectedChoiceId,
//                    QuizResultId = quizResult.QuizResultId
//                });
//            }

//            return new QuizResultToReturnDto
//            {
//                StudentId = dto.StudentId,
//                QuizId = dto.QuizId,
//                Score = score,
//                Ispassed = isPassed,
//                TakenAt = quizResult.TakenAt
//            };


//        }

//    }

//}
