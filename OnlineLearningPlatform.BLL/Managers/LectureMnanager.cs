using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class LectureMnanager : ILectureManager
    {
        private ILectureRepository _lectureRepository;
        public LectureMnanager(ILectureRepository lectureRepository) { 
                _lectureRepository = lectureRepository;
        }
        public IEnumerable<LectureReadDto> GetAll()
        {
            var lectureModels = _lectureRepository.GetAll();

            //convert from model to Dto
            var lectureDtos = lectureModels.Select(a=>new LectureReadDto
            {
                LectureId = a.LectureId,
                CourseId = a.CourseId,
                Title = a.Title,
                Description = a.Description,
                OrderInCourse = a.OrderInCourse,
                VideoUrl = a.VideoUrl

            }).ToList();

            return lectureDtos;
                        
        }

        public LectureReadDto GetById(int id)
        {
            var lectureModel = _lectureRepository.GetById(id);

            var lectureDto = new LectureReadDto
            {
                LectureId = lectureModel.LectureId,
                CourseId = lectureModel.CourseId,
                Title = lectureModel.Title,
                Description = lectureModel.Description,
                OrderInCourse = lectureModel.OrderInCourse,
                VideoUrl = lectureModel.VideoUrl

            };

            return lectureDto;

        }

        public void Insert(LectureAddDto lecture)
        {
            var lectureModel = new Lecture
            {
                OrderInCourse = lecture.OrderInCourse,
                CourseId = lecture.CourseId,
                Title = lecture.Title,
                Description = lecture.Description,
                VideoUrl = lecture.VideoUrl
                
            };
            _lectureRepository.Insert(lectureModel);
        }

        public void Update(LectureUpdateDto lecture)
        {
            var lectureModel = _lectureRepository.GetById(lecture.LectureId);

                lectureModel.CourseId = lecture.CourseId;
                lectureModel.OrderInCourse = lecture.OrderInCourse;
                lectureModel.LectureId = lecture.LectureId;
                lectureModel.Description = lecture.Description; 
                lectureModel.Title = lecture.Title;
                lectureModel.VideoUrl = lecture.VideoUrl;
            
            _lectureRepository.Update(lectureModel);
        }
        public void Delete(int id)
        {
            var lectureModel = _lectureRepository.GetById(id);
            _lectureRepository.Delete(lectureModel);
        }
    }
}
