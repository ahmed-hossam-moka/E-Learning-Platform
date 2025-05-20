using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository.Quizs
{
    public class QuizRepository : IQuizRepository
    {
        private readonly PlatformContext _context;

        public QuizRepository(PlatformContext context)
        {
            _context = context;
        }

        public async Task CreateQuizAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Quiz>> GetAllAsync(int courseId)
             => await _context.Set<Quiz>().Where(q => q.CourseId == courseId).Select(q => q).ToListAsync();

        public async Task<Quiz> GetByIdAsync(int id)
           => await _context.Set<Quiz>().FirstOrDefaultAsync(q => q.QuizId == id);

        public async Task RemoveById(int id)
          => _context.Set<Quiz>().Remove(await GetByIdAsync(id));


        public async Task<int> CompleteAsync()
         => await _context.SaveChangesAsync();






        public async Task<List<Question>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _context.Questions
                .Include(q => q.Choices)
                .Where(q => q.QuizId == quizId)
                .ToListAsync();
        }




        public async Task<Quiz> GetQuizWithQuestionsAndChoicesAsync(int quizId)
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Choices)
                .FirstOrDefaultAsync(q => q.QuizId == quizId);
        }

        public async Task AddQuizResultAsync(QuizResult result)
        {
            await _context.QuizResults.AddAsync(result);
        }

        public async Task AddStudentAnswerAsync(StudentAnswer answer)
        {
            await _context.StudentAnswers.AddAsync(answer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        //public async Task CreateAsync(Quiz quiz)
        //   => await _context.Set<Quiz>().AddAsync(quiz);



        //public async Task<Quiz> GetFullQuizByIdAsync(int id)
        //{
        //    return await _context.Quizzes
        //        .Include(a => a.Questions)
        //            .ThenInclude(a => a.Choices)
        //        .FirstOrDefaultAsync(a => a.QuizId == id);
        //}

        //public async Task<List<Question>> GetQuestionsByQuizIdAsync(int quizId)
        //{
        //    return await _context.Questions
        //        .Include(q => q.Choices)
        //        .Where(q => q.QuizId == quizId)
        //        .ToListAsync();
        //}

    }
}
