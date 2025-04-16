using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IInstructorRepository
    {
        public IQueryable<Instructor> GetAll();
        public Instructor GetById(int id);
        public void Add(Instructor instructor);
        public void Update(Instructor instructor, int id);
        public void Delete(int id);
    }
}
