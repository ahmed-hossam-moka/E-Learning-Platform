using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class LectureRepository : ILectureRepository
    {
        private readonly PlatformContext _context;

        public LectureRepository(PlatformContext context)
        {
           _context = context;
        }

        public IQueryable<Lecture> GetAll()
        {
            return _context.Lectures;
        }

        public Lecture GetById(int id) => _context.Lectures.Find(id);

        public void Insert(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            _context.SaveChanges();
        }

        public void Update(Lecture lecture)
        {
            //_context.Lectures.Update(lecture);
            _context.SaveChanges();
        }
        public void Delete(Lecture lecture)
        {
            _context.Lectures.Remove(lecture);
            _context.SaveChanges();
        }
    }
}
