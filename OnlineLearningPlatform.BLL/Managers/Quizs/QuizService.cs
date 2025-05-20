using OnlineLearningPlatform.BLL.Dtos.Quizs;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository.Quizs;


namespace OnlineLearningPlatform.BLL.Managers.Quizs
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IQuestionRepository _questionRepository;


        public QuizService(IQuizRepository quizRepository, IQuestionRepository questionRepository)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
        }
        public async Task CreateQuizAsync(CreateQuizDto createQuizDto)
        {
            var quiz = new Quiz
            {
                CourseId = createQuizDto.CourseId,
                Title = createQuizDto.Title,
                PassingScore = createQuizDto.PassingScore,
                Questions = createQuizDto.Questions.Select(q => new Question
                {
                    Text = q.Text,
                    Choices = q.Choices.Select(c => new AnswerChoice
                    {
                        Text = c.Text,
                        IsCorrect = c.IsCorrect
                    }).ToList()
                }).ToList()
            };

            await _quizRepository.CreateQuizAsync(quiz);
        }

        public async Task<int> DeleteQuizAsync(int id)
        {
            Quiz quiz = await _quizRepository.GetByIdAsync(id);
            if (quiz == null) throw new Exception("Quiz not found!");

            _quizRepository.RemoveById(id);
            return await _quizRepository.CompleteAsync();
        }
        public async Task<List<QuizToReturnDto>> GetAllQuizzesAsync(int courseId)
        {
            var Quizzes = await _quizRepository.GetAllAsync(courseId);

            var quizzesDtos = Quizzes.Select(q => new QuizToReturnDto
            {
                Title = q.Title,
                CreatedAt = q.CreatedAt,
                PassingScore = q.PassingScore,
            }).ToList();
            return quizzesDtos;
        }






        public async Task<List<QuestionWithChoicesDto>> GetQuizQuestionsAsync(int quizId)
        {
            var questions = await _questionRepository.GetQuestionsByQuizIdAsync(quizId);

            return questions.Select(q => new QuestionWithChoicesDto
            {
                QuestionId = q.QuestionId,
                Text = q.Text,
                Choices = q.Choices.Select(c => new ChoiceDto
                {
                    ChoiceId = c.AnswerChoiceId,
                    Text = c.Text
                }).ToList()
            }).ToList();
        }






        public async Task<QuizResultDto> SubmitQuizAsync(SubmitQuizDto dto)
        {
            var quiz = await _quizRepository.GetQuizWithQuestionsAndChoicesAsync(dto.QuizId);
            if (quiz == null)
                throw new Exception("Quiz not found.");

            int totalQuestions = quiz.Questions.Count;
            int correctAnswers = 0;

            var quizResult = new QuizResult
            {
                StudentId = dto.StudentId,
                QuizId = dto.QuizId,
                SubmittedAt = DateTime.UtcNow,
                Score = 0 // temporary
            };

            await _quizRepository.AddQuizResultAsync(quizResult);

            foreach (var answer in dto.Answers)
            {
                var question = quiz.Questions.FirstOrDefault(q => q.QuestionId == answer.QuestionId);
                if (question == null) continue;

                var selectedChoice = question.Choices.FirstOrDefault(c => c.AnswerChoiceId == answer.SelectedChoiceId);
                if (selectedChoice == null) continue;

                bool isCorrect = selectedChoice.IsCorrect;
                if (isCorrect) correctAnswers++;

                var studentAnswer = new StudentAnswer
                {
                    QuizResult = quizResult,
                    QuestionId = question.QuestionId,
                    SelectedAnswerId = selectedChoice.QuestionId,
                    IsCorrect = isCorrect
                };

                await _quizRepository.AddStudentAnswerAsync(studentAnswer);
            }

            quizResult.Score = (int)Math.Round((double)(correctAnswers * 100) / totalQuestions);
            quizResult.Ispassed = quizResult.Score >= quiz.PassingScore;

            await _quizRepository.SaveChangesAsync();

            return new QuizResultDto
            {
                Score = quizResult.Score,
                Ispassed = quizResult.Ispassed
            };
        }




        //    public async Task<QuizToReturnDto> CreateQuizAsync(CreateQuizDto createQuizDto)
        //    {
        //        var quiz = new Quiz
        //        {
        //            CourseId = createQuizDto.CourseId,
        //            Title = createQuizDto.Title,
        //            PassingScore = createQuizDto.PassingScore,
        //            CreatedAt = DateTime.UtcNow,
        //            Questions = createQuizDto.Questions.Select(q => new Question
        //            {
        //                Text = q.Text,
        //                Choices = q.Choices.Select(c => new AnswerChoice
        //                {
        //                    Text = c.Text,
        //                    IsCorrect = c.IsCorrect
        //                }).ToList()
        //            }).ToList()
        //        };

        //        await _quizRepository.CreateAsync(quiz);
        //        await _quizRepository.CompleteAsync();

        //        return new QuizToReturnDto
        //        {
        //            CreatedAt = quiz.CreatedAt,
        //            PassingScore = quiz.PassingScore,
        //            Title = quiz.Title,
        //        };
        //    }




        //    public async Task AddQuestionAsync(CreateQuestionDto dto)
        //    {
        //        var question = new Question
        //        {
        //            Text = dto.Text,
        //            QuizId = dto.QuizId,
        //            Choices = dto.Choices.Select(c => new AnswerChoice
        //            {
        //                Text = c.Text,
        //                IsCorrect = c.IsCorrect
        //            }).ToList()
        //        };

        //        await _questionRepository.AddAsync(question);
        //        await _questionRepository.CompleteAsync();
        //    }

        //}
    }
}