using OnlineLearningPlatform.BLL.Dtos;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface IUserLectureProgressService
    {
        Task MarkAsCompletedAsync(string id);
        Task<UserLectureProcessToReturnDto> ViewStudentProgressAsync(string id);
    }
}
