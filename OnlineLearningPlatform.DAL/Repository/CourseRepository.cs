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
    public class CourseRepository : ICourseRepository
    {
        private readonly PlatformContext _context;

        public CourseRepository(PlatformContext context)
        {
            _context = context;
        }


        public IQueryable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetById(int Id)
        {
            //return _context.Courses.Find(Id);
            //return _context.Courses.FirstOrDefault(a => a.CourseId == Id);
            return _context.Courses
                                    .Include(c => c.Instructor) // Load Instructor
                                    .Include(c => c.Category)   // Load Category
                                    .FirstOrDefault(c => c.CourseId == Id);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            //_context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void Delete(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();

        }
        public (IEnumerable<Course> items, int totalCount) GetPaginated(int pageNumber, int pageSize)
        {
            var query = _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Category);

            // Get total count of ALL matching records
            var totalCount = query.Count();

            var items = query
                .Skip((pageNumber - 1) * pageSize)  // Jump to correct page
                .Take(pageSize)                     // Take only the page size
                .ToList();

            return (items, totalCount);
        }
    }
}
