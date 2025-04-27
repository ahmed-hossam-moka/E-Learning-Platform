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
    public interface ICourseRepository
    {
        public IQueryable<Course> GetAll();
        public Course GetById(int Id);
        public void Add(Course course);
        public void Update(Course course);
        public void Delete(Course course);

    }
}
