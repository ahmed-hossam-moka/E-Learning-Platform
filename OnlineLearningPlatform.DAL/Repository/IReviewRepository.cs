using OnlineLearningPlatform.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IReviewRepository
    {
        IQueryable<Review> GetAll();
        Review GetById(int id);
        IEnumerable<Review> GetReviewsByCourse(int courseId);
        IEnumerable<Review> GetReviewsByStudent(int studentId);
        void Add(Review review);
        void Update(Review review, int id);
        void Delete(int id);
    }
}