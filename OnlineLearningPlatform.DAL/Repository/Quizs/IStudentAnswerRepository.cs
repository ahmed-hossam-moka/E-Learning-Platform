using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository.Quizs
{
    public interface IStudentAnswerRepository
    {
        Task AddAsync(StudentAnswer answer);
        Task<List<StudentAnswer>> GetByResultIdAsync(int resultId);
        Task<int> CompleteAsync();
    }
}
