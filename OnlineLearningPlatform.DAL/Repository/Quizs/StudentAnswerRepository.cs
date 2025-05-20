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
    public class StudentAnswerRepository : IStudentAnswerRepository
    {
        private readonly PlatformContext _context;

        public StudentAnswerRepository(PlatformContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StudentAnswer answer)
            => await _context.StudentAnswers.AddAsync(answer);

        public async Task<List<StudentAnswer>> GetByResultIdAsync(int resultId)
            => await _context.StudentAnswers
                             .Where(a => a.QuizResultId == resultId)
                             .Include(a => a.Question)
                             .Include(a => a.SelectedAnswer)
                             .ToListAsync();

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();
    }
}
