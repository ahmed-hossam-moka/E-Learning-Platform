using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly PlatformContext _platformContext;

        public InstructorRepository(PlatformContext platformContext)
        {
            _platformContext = platformContext;
        }
        public IQueryable<Instructor> GetAll()
        {
            return _platformContext.Instructors;
        }

        public Instructor GetById(int id)
        {
            return _platformContext.Instructors.FirstOrDefault(a => a.InstructorId == id);
        }
        public void Add(Instructor instructor)
        {
            _platformContext.Instructors.Add(instructor);
            _platformContext.SaveChanges();
        }
        public void Update(Instructor instructor, int id)
        {
            _platformContext.Instructors.Where(a => a.InstructorId == id)
                                        .ExecuteUpdate(a => a
                                            .SetProperty(a => a.InstructorId, a => a.InstructorId)
                                            .SetProperty(a => a.Announcements, a => a.Announcements)
                                            .SetProperty(a => a.Bio, a => a.Bio)
                                            .SetProperty(a => a.Courses, a => a.Courses)
                                            .SetProperty(a => a.Earnings, a => a.Earnings)
                                            .SetProperty(a => a.Name, a => a.Name)
                                            .SetProperty(a => a.ProfilePictureUrl, a => a.ProfilePictureUrl)
                                            .SetProperty(a => a.UpdatedAt, a => a.UpdatedAt)
                                            .SetProperty(a => a.CreatedAt, a => a.CreatedAt)
                                            .SetProperty(a => a.User, a => a.User)
                                            .SetProperty(a => a.Withdrawals, a => a.Withdrawals)
                                            .SetProperty(a => a.IsApproved, a => a.IsApproved));
        }
        public void Delete(int id)
        {
            _platformContext.Instructors.Where(a => a.InstructorId == id).ExecuteDelete();
        }

    }
}
