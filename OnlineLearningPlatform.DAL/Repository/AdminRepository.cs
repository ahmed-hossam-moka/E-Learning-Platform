
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly PlatformContext _context;

        public AdminRepository(PlatformContext context)
        {
            _context = context;
        }

        public IQueryable<Instructor> GetPendingInstructors()
        {
            return _context.Instructors
                .Include(i => i.User)  // Eager load  for related User data
                .Where(i => !i.IsApproved); // Only unapproved instructors
        }

        public IQueryable<Course> GetPendingCourses()
        {
            return _context.Courses
                .Include(c => c.Instructor)  // Eager load Instructor
                .Where(c => !c.IsApproved);
        }

        public void ApproveInstructor(string instructorId, bool isApproved)
        {
            _context.Instructors
                .Where(i => i.UserId == instructorId)
                .ExecuteUpdate(i => i
                    .SetProperty(i => i.IsApproved, isApproved)
                    .SetProperty(i => i.UpdatedAt, DateTime.UtcNow));
        }

        public void ApproveCourse(int courseId, bool isApproved)
        {
            _context.Courses
                .Where(c => c.CourseId == courseId)
                .ExecuteUpdate(c => c
                    .SetProperty(c => c.IsApproved, isApproved)
                    .SetProperty(c => c.UpdatedAt, DateTime.UtcNow));
        }
    }
}