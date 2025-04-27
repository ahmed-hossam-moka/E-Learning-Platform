using OnlineLearningPlatform.BLL.Dtos.Admin;
using System.Collections.Generic;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface IAdminManager
    {
        // Queries
        IEnumerable<PendingInstructorReadDto> GetPendingInstructors();
        IEnumerable<PendingCourseReadDto> GetPendingCourses();

        // Commands
        void ApproveInstructor(InstructorApprovalDto approvalDto);
        void ApproveCourse(CourseApprovalDto approvalDto);
        void RejectInstructor(int instructorId, string? rejectionReason = null);
        void RejectCourse(int courseId, string? rejectionReason = null);
    }
}