using OnlineLearningPlatform.BLL.Dtos.Admin;
using OnlineLearningPlatform.DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository _adminRepository;

        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IEnumerable<PendingInstructorReadDto> GetPendingInstructors()
        {
            return _adminRepository.GetPendingInstructors()
                .Select(i => new PendingInstructorReadDto
                {
                    InstructorId = i.InstructorId,
                    Name = i.Name,
                    Email = i.User.Email,
                    Bio = i.Bio
                }).ToList();
        }

        public IEnumerable<PendingCourseReadDto> GetPendingCourses()
        {
            return _adminRepository.GetPendingCourses()
                .Select(c => new PendingCourseReadDto
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorId = c.InstructorId,
                    InstructorName = c.Instructor.Name,
                    CreatedAt = c.CreatedAt
                }).ToList();
        }

        public void ApproveInstructor(InstructorApprovalDto approvalDto)
        {
            _adminRepository.ApproveInstructor(approvalDto.InstructorId, true);
        }

        public void ApproveCourse(CourseApprovalDto approvalDto)
        {
            _adminRepository.ApproveCourse(approvalDto.CourseId, true);
        }

        public void RejectInstructor(int instructorId, string rejectionReason = null)
        {
            _adminRepository.ApproveInstructor(instructorId, false);
            // to store rejection reason, add this method to repository:
            // _adminRepository.AddInstructorRejectionReason(instructorId, rejectionReason);
        }

        public void RejectCourse(int courseId, string rejectionReason = null)
        {
            _adminRepository.ApproveCourse(courseId, false);
            // to store rejection reason, add this method to repository:
            // _adminRepository.AddCourseRejectionReason(courseId, rejectionReason);
        }
    }
}