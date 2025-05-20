using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IUserLectureProgressRepository
    {
        Task<UserLectureProgress> GetByIdAsync(string id);
        Task<int> CompleteAsync();
    }
}
