using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository.Quizs
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly PlatformContext _context;

        public QuestionRepository(PlatformContext context)
        {
            _context = context;
        }

        public async Task<Question> GetByIdAsync(int id)
            => await _context.Questions.Include(q => q.Choices)
                                       .FirstOrDefaultAsync(q => q.QuestionId == id);

        public async Task<List<Question>> GetAllByQuizIdAsync(int quizId)
            => await _context.Questions
                             .Where(q => q.QuizId == quizId)
                             .Include(q => q.Choices)
                             .ToListAsync();

        public async Task AddAsync(Question question)
            => await _context.Questions.AddAsync(question);

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public async Task<List<Question>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _context.Questions
                .Include(q => q.Choices)
                .Where(q => q.QuizId == quizId)
                .ToListAsync();
        }
    }
}
