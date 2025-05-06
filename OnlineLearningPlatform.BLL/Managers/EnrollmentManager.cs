using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class EnrollmentManager : IEnrollmentManager
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentManager(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public void Delete(int id)
        {
            var enrollmentModel = _enrollmentRepository.GetById(id);
            _enrollmentRepository.Delete(enrollmentModel);
        }

        public IEnumerable<EnrollmentReadDto> GetAll()
        {
            var enrollmentModels = _enrollmentRepository.GetAll();
            var enrollmentDtos = enrollmentModels.Select(a => new EnrollmentReadDto
            {
                EnrollmentId = a.EnrollmentId,
                StudentId = a.StudentId,
                CourseId = a.CourseId,
                PaymentId = a.PaymentId,
                EnrollmentDate = a.EnrollmentDate,
                IsCompleted = a.IsCompleted,
                CompletedDate = a.CompletedDate,
            }).ToList();
            return enrollmentDtos;
        }

        public EnrollmentReadDto GetById(int id)
        {
            var enrollmentModel = _enrollmentRepository.GetById(id);
            var enrollmentDto = new EnrollmentReadDto
            {
                EnrollmentId = enrollmentModel.EnrollmentId,
                StudentId = enrollmentModel.StudentId,
                CourseId = enrollmentModel.CourseId,
                PaymentId = enrollmentModel.PaymentId,
                EnrollmentDate = enrollmentModel.EnrollmentDate,
                IsCompleted = enrollmentModel.IsCompleted,
                CompletedDate = enrollmentModel.CompletedDate,
            };
            return enrollmentDto;

        }

        public void Insert(EnrollmentAddDto enrollment)
        {
            var enrollmentModel = new Enrollment
            {
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                PaymentId = enrollment.PaymentId,
                EnrollmentDate = enrollment.EnrollmentDate
            };
            _enrollmentRepository.Insert(enrollmentModel);
        }
    }
}
