using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository.Users
{
    public interface IInstructorRepository
    {
        public IQueryable<Instructor> GetAll();
        public Instructor GetById(string id);
        public void Update(Instructor instructor, string id);
        public void Delete(string id);
    }
}
