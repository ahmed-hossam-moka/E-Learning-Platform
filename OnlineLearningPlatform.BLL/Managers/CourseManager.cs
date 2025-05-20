using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseReadDto> GetAll()
        {
            var courseModels = _courseRepository.GetAll();
            var courseDtos = courseModels.Select(a => new CourseReadDto
            {
                CourseId = a.CourseId,
                Title = a.Title,
                Description = a.Description,
                Price = a.Price,
                ImageUrl = a.ImageUrl,
                Status = a.Status,
                IsApproved = a.IsApproved,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                InstructorName = a.Instructor.Name,
                CategoryName = a.Category.Name
            }).ToList();
            return courseDtos;
        }
        public CourseReadDto GetById(int Id)
        {
            var courseModel = _courseRepository.GetById(Id);
            var courseDto = new CourseReadDto
            {
                CourseId = courseModel.CourseId,
                Title = courseModel.Title,
                Description = courseModel.Description,
                Price = courseModel.Price,
                ImageUrl = courseModel.ImageUrl,
                Status = courseModel.Status,
                IsApproved = courseModel.IsApproved,
                CreatedAt = courseModel.CreatedAt,
                UpdatedAt = courseModel.UpdatedAt,
                InstructorName = courseModel.Instructor.Name,
                CategoryName = courseModel.Category.Name
                //InstructorName=GetById
            };
            return courseDto;
        }



        public void Add(CourseAddDto course)
        {
            var courseModel = new Course
            {
                InstructorId = course.InstructorId,
                CategoryId = course.CategoryId,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ImageUrl = course.ImageUrl,
                Status = course.Status,
                IsApproved = course.IsApproved
            };
            _courseRepository.Add(courseModel);

        }

        

       
        public void Update(CourseUpdateDto course)
        {
            var courseModel = _courseRepository.GetById(course.CourseId);
            courseModel.InstructorId = course.InstructorId;
            courseModel.CategoryId = course.CategoryId;
            courseModel.Title = course.Title;
            courseModel.Description = course.Description;
            courseModel.Price = course.Price;
            courseModel.ImageUrl = course.ImageUrl;
            courseModel.Status = course.Status;
            courseModel.IsApproved = course.IsApproved;
            _courseRepository.Update(courseModel);

        }

        public void Delete(int Id)
        {
            var courseModel = _courseRepository.GetById(Id);
            _courseRepository.Delete(courseModel);
        }
    }
}
