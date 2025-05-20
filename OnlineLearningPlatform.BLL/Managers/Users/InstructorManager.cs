using OnlineLearningPlatform.BLL.Dtos.Users;
using OnlineLearningPlatform.DAL.Repository.Users;

namespace OnlineLearningPlatform.BLL.Managers.Users
{
    public class InstructorManager : IInstructorManager
    {
        private readonly IInstructorRepository _InstructorRepository;
        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _InstructorRepository = instructorRepository;
        }
        public IEnumerable<InstructorReadDto> GetAll()
        {
            var instructorModele = _InstructorRepository.GetAll();

            var instructorDto = instructorModele
            .Select(a => new InstructorReadDto
            {
                Name = a.Name,
                ProfilePictureUrl = a.ProfilePictureUrl,
                Bio = a.Bio,
                IsApproved = a.IsApproved,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,

            })
            .ToList();

            return instructorDto;
        }

        public InstructorReadDto GetById(string Id)
        {
            var instructorModele = _InstructorRepository.GetById(Id);

            if (instructorModele == null)
                throw new Exception("User not found");

            var instructorDto = new InstructorReadDto
            {
                Name = instructorModele.Name,
                ProfilePictureUrl = instructorModele.ProfilePictureUrl,
                Bio = instructorModele.Bio,
                IsApproved = instructorModele.IsApproved,
                CreatedAt = instructorModele.CreatedAt,
                UpdatedAt = instructorModele.UpdatedAt,

            };

            return instructorDto;
        }

        public void Update(InstructorUpdateDto instructor)
        {
            var instructorModel = _InstructorRepository.GetById(instructor.InstructorId);

            instructorModel.UserId = instructor.InstructorId;
            instructorModel.Name = instructor.Name;
            instructorModel.ProfilePictureUrl = instructor.ProfilePictureUrl;
            instructorModel.Bio = instructor.Bio;

            _InstructorRepository.Update(instructorModel, instructorModel.UserId);
        }
        public void Delete(string Id)
        {
            // need to test before push in github
            _InstructorRepository.Delete(Id);
        }



    }
}
