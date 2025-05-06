using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository.Users
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

        public Instructor GetById(string id)
        {
            var instructor = _platformContext.Instructors.FirstOrDefault(a => a.UserId == id);

            return instructor;
        }
 
        public void Update(Instructor instructor, string id)
        {
            _platformContext.Instructors.Where(a => a.UserId == id)
                                        .ExecuteUpdate(a => a
                                            .SetProperty(a => a.UserId, instructor.UserId)
                                            .SetProperty(a => a.Bio, instructor.Bio)
                                            .SetProperty(a => a.Name, instructor.Name)
                                            .SetProperty(a => a.ProfilePictureUrl, instructor.ProfilePictureUrl)
                                            .SetProperty(a => a.UpdatedAt, instructor.UpdatedAt));
        }
        public void Delete(string id)
        {
            _platformContext.Instructors.Where(a => a.UserId == id).ExecuteDelete();
        }

    }
}
