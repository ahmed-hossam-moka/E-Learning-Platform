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
    public class StudentRepository : IStudentRepository
    {
        private readonly PlatformContext _platformContext;
        public StudentRepository(PlatformContext platformContext)
        {
            _platformContext = platformContext;
        }
        public IQueryable<Student> GetAll()
        {
            return _platformContext.Students;
        }
        public Student? GetById(string id)
        {
            return _platformContext.Students.FirstOrDefault(a => a.UserId == id);

        }
        public void Update(Student student, string id)
        {
            _platformContext.Students.Where(a => a.UserId == id).ExecuteUpdate(a => a
                                                                            .SetProperty(a => a.UserId, student.UserId)
                                                                            .SetProperty(a => a.Name, student.Name)
                                                                            .SetProperty(a => a.ProfilePictureUrl, student.ProfilePictureUrl)
                                                                            .SetProperty(a => a.UpdatedAt, student.UpdatedAt));
        }
        public void Delete(string id)
        {
            _platformContext.Students.Where(a => a.UserId == id).ExecuteDelete();
        }
    }
}
