using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly PlatformContext _context;

        public EnrollmentRepository(PlatformContext context) {
            _context = context;
        }
        public void Delete(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
        }

        public IQueryable<Enrollment> GetAll()
        {
            return _context.Enrollments;
        }

        public Enrollment GetById(int id)
        {
            return _context.Enrollments.Find(id);
        }

        public void Insert(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }
    }
}
