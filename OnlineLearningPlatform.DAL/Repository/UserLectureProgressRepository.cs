using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class UserLectureProgressRepository : IUserLectureProgressRepository
    {
        private readonly PlatformContext _platformContext;

        public UserLectureProgressRepository(PlatformContext platformContext)
        {
            _platformContext = platformContext;
        }
        public async Task<UserLectureProgress> GetByIdAsync(string id)
            => await _platformContext.Set<UserLectureProgress>().FirstOrDefaultAsync(x => x.StudentId == id);

        public async Task<int> CompleteAsync()
         => await _platformContext.SaveChangesAsync();
    }
}
