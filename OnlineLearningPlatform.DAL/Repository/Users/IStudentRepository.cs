using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository.Users
{
    public interface IStudentRepository
    {
        public IQueryable<Student> GetAll();

        public Student GetById(string id);
        public void Update(Student student, string id);
        public void Delete(string id);

    }
}
