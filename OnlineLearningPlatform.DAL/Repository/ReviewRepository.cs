using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly PlatformContext _context;

        public ReviewRepository(PlatformContext context)
        {
            _context = context;
        }

        public IQueryable<Review> GetAll()
        {
            return _context.Reviews.AsQueryable();
        }

        public Review GetById(int id)
        { 
            return _context.Reviews.FirstOrDefault(r => r.ReviewId == id);
        }

        public IEnumerable<Review> GetReviewsByCourse(int courseId)
        { 
            return _context.Reviews.Where(r => r.CourseId == courseId).ToList();
        }

        public IEnumerable<Review> GetReviewsByStudent(int studentId)
        {
            return _context.Reviews.Where(r => r.StudentId == studentId).ToList();
        } 

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void Update(Review review, int id)
        {
            _context.Reviews
                .Where(r => r.ReviewId == id)
                .ExecuteUpdate(r => r
                    .SetProperty(r => r.Rating, review.Rating)
                    .SetProperty(r => r.Comment, review.Comment)
                    .SetProperty(r => r.CreatedAt, review.CreatedAt));
        }

        public void Delete(int id)
        {
            _context.Reviews.Where(r => r.ReviewId == id).ExecuteDelete();
        }
    }
}