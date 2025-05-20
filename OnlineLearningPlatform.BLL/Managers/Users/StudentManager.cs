using OnlineLearningPlatform.BLL.Dtos.Users;
using OnlineLearningPlatform.DAL.Repository.Users;

namespace OnlineLearningPlatform.BLL.Managers.Users
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepository;
        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IEnumerable<StudentReadDto> GetAll()
        {
            var studentsModel = _studentRepository.GetAll();

            var studentsDto = studentsModel.Select(a => new StudentReadDto
            {
                Name = a.Name,
                CreatedAt = a.CreatedAt,
                ProfilePictureUrl = a.ProfilePictureUrl,
                UpdatedAt = a.UpdatedAt,

            }).ToList();
            return studentsDto;
        }
        public StudentReadDto GetById(string id)
        {
            var studentModel = _studentRepository.GetById(id);

            var studenDto = new StudentReadDto
            {
                Name = studentModel.Name,
                ProfilePictureUrl = studentModel.ProfilePictureUrl,
                CreatedAt = studentModel.CreatedAt,
                UpdatedAt = studentModel.UpdatedAt
            };
            return studenDto;

        }
        public void Update(StudentUpdateDto studentDto)
        {
            var studentModel = _studentRepository.GetById(studentDto.StudentId);

            studentModel.Name = studentDto.Name;
            studentModel.ProfilePictureUrl = studentDto.ProfilePictureUrl;
            studentModel.UpdatedAt = studentDto.UpdatedAt;

            _studentRepository.Update(studentModel, studentModel.UserId);
        }
        public void Delete(string id)
        {
            _studentRepository.Delete(id);
        }
    }

}
