//using Microsoft.EntityFrameworkCore;
//using OnlineLearningPlatform.DAL.DataBase;
//using OnlineLearningPlatform.DAL.Models;
//using OnlineLearningPlatform.DAL.Repository.Quizs;

//namespace OnlineLearningPlatform.DAL.Repository
//{
//    public class QuizResultRepository : IQuizResultRepository
//    {
//        private readonly PlatformContext _context;

//        public QuizResultRepository(PlatformContext context)
//        {
//            _context = context;
//        }

//        public async Task<QuizResult> GetByQuizResultIdAsync(int quizResultId)
//        {
//            return await _context.QuizResults
//                .AsNoTracking()
//                .FirstOrDefaultAsync(qr => qr.QuizResultId == quizResultId);
//        }



//        public async Task CreateAsync(QuizResult quizresult)
//           => await _context.Set<QuizResult>().AddAsync(quizresult);

//        public async Task<List<QuizResult>> GetByIdAsync(int quizId)
//         => await _context.Set<QuizResult>().Where(qr => qr.QuizId == quizId).ToListAsync();


//        public async Task<int> CompleteAsync()
//           => await _context.SaveChangesAsync();
//    }
//}
