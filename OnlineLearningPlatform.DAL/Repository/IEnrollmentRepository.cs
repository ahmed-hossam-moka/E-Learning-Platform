using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IEnrollmentRepository
    {
        IQueryable<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Insert(Enrollment enrollment);
        void Delete(Enrollment enrollment);
    }
}
