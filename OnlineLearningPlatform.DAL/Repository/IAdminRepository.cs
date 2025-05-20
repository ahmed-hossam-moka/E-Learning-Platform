// OnlineLearningPlatform.DAL/Repository/IAdminRepository.cs
using OnlineLearningPlatform.DAL.Models;
using System.Linq;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IAdminRepository
    {
        IQueryable<Instructor> GetPendingInstructors();
        IQueryable<Course> GetPendingCourses();
        void ApproveInstructor(string instructorId, bool isApproved);
        void ApproveCourse(int courseId, bool isApproved);
    }
}