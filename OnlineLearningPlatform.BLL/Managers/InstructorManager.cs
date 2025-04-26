using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers
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

        public InstructorReadDto GetById(int Id)
        {
            var instructorModele = _InstructorRepository.GetById(Id);

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
        public void Add(InstructorAddDto instructor)
        {
            var istructorModel = new Instructor
            {
                InstructorId=instructor.InstructoId,
                Name = instructor.Name,
                ProfilePictureUrl = instructor.ProfilePictureUrl,
                Bio = instructor.Bio,
                IsApproved = instructor.IsApproved,
            };

            _InstructorRepository.Add(istructorModel);

        }
        public void Update(InstructorUpdateDto instructor)
        {
            var instructorModel = _InstructorRepository.GetById(instructor.InstructorId);

            instructorModel.InstructorId = instructor.InstructorId;
            instructorModel.Name = instructor.Name;
            instructorModel.ProfilePictureUrl  = instructor.ProfilePictureUrl;
            instructorModel.Bio = instructor.Bio;
            instructorModel.IsApproved = instructor.IsApproved;

            _InstructorRepository.Update(instructorModel, instructorModel.InstructorId);
        }
        public void Delete(int Id)
        {
            // need to test before push in github
            _InstructorRepository.Delete(Id);
        }



    }
}
