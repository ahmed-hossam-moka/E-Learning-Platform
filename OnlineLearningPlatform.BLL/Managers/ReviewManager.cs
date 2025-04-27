// BLL/Managers/ReviewManager.cs
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.BLL.Dtos.Reviews;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;


namespace OnlineLearningPlatform.BLL.Managers
{
    public class ReviewManager : IReviewManager
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewManager(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<ReviewReadDto> GetAll()
        {
            var reviews = _reviewRepository.GetAll();
            return reviews.Select(r => new ReviewReadDto
            {
                ReviewId = r.ReviewId,
                StudentId = r.StudentId,
                CourseId = r.CourseId,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            }).ToList();
        }

        public ReviewReadDto GetById(int id)
        {
            var review = _reviewRepository.GetById(id);
            return new ReviewReadDto
            {
                ReviewId = review.ReviewId,
                StudentId = review.StudentId,
                CourseId = review.CourseId,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt
            };
        }


       
        public void Add(ReviewAddDto review)
        {
            var reviewModel = new Review
            {
                StudentId = review.StudentId,
                CourseId = review.CourseId,
                Rating = review.Rating,
                Comment = review.Comment
            };
            _reviewRepository.Add(reviewModel);
        }

        public void Update(ReviewUpdateDto review)
        {
            var reviewModel = _reviewRepository.GetById(review.ReviewId);
            reviewModel.Rating = review.Rating;
            reviewModel.Comment = review.Comment;
            _reviewRepository.Update(reviewModel, review.ReviewId);
        }

        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }
    }
}