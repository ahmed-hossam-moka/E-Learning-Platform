
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Repository;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class UserLectureProgressService : IUserLectureProgressService
    {
        private readonly IUserLectureProgressRepository _userLectureProgressRepository;

        public UserLectureProgressService(IUserLectureProgressRepository userLectureProgressRepository)

        {
            _userLectureProgressRepository = userLectureProgressRepository;
        }
        public async Task MarkAsCompletedAsync(string id)
        {
            var userlectureprogress = await _userLectureProgressRepository.GetByIdAsync(id);
            userlectureprogress.IsCompleted = true;
            await _userLectureProgressRepository.CompleteAsync();
        }

        public async Task<UserLectureProcessToReturnDto> ViewStudentProgressAsync(string id)
        {
            var userlectureprogress = await _userLectureProgressRepository.GetByIdAsync(id);


            return new UserLectureProcessToReturnDto()
            {
                CompletedAt = userlectureprogress.CompletedAt,
                IsCompleted = userlectureprogress.IsCompleted,
                LectureId = userlectureprogress.LectureId,
                ProgressId = userlectureprogress.ProgressId,
                StudentId = userlectureprogress.StudentId,
            };
        }
    }
}
