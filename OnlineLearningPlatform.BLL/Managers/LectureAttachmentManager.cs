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
    public class LectureAttachmentManager : ILectureAttachmentManager
    {
        private readonly ILectureAttachmentRepository _lectureAttachmentRepository;

        public LectureAttachmentManager(ILectureAttachmentRepository lectureAttachmentRepository) {
            _lectureAttachmentRepository = lectureAttachmentRepository;

                    }

        public IEnumerable<LectureAttachmentReadDto> GetAll()
        {
            var lectureAttachmentModels = _lectureAttachmentRepository.GetAll();

            //convert from model to Dto
            var lectureAttachmentDtos = lectureAttachmentModels.Select(a => new LectureAttachmentReadDto
            {
                LectureId = a.LectureId,
                AttachmentId = a.AttachmentId,
                Lecture = a.Lecture,
                FileUrl= a.FileUrl,
            }).ToList();

            return lectureAttachmentDtos;
        }

        public LectureAttachmentReadDto GetById(int id)
        {
            var lectureAttachmentModel = _lectureAttachmentRepository.GetById(id);

            var lectureAttachmentDto = new LectureAttachmentReadDto
            {
                LectureId = lectureAttachmentModel.LectureId,
                AttachmentId = lectureAttachmentModel.AttachmentId,
                Lecture = lectureAttachmentModel.Lecture,
                FileUrl = lectureAttachmentModel.FileUrl,
             };

            return lectureAttachmentDto;
        }

        public void Insert(LectureAttachmentAddDto lectureAttachment)
        {
            var lectureAttachmentModel = new LectureAttachment
            {
                LectureId = lectureAttachment.LectureId,
                Lecture = lectureAttachment.Lecture,
                FileUrl = lectureAttachment.FileUrl,
                AttachmentId= lectureAttachment.AttachmentId,
             };
            _lectureAttachmentRepository.Insert(lectureAttachmentModel);
        }

        public void Update(LectureAttachmentUpdateDto lectureAttachment)
        {
            var lectureAttachmentModel = _lectureAttachmentRepository.GetById(lectureAttachment.LectureId);

            lectureAttachmentModel.LectureId = lectureAttachment.LectureId;
            lectureAttachmentModel.Lecture= lectureAttachment.Lecture;
            lectureAttachmentModel.AttachmentId= lectureAttachment.AttachmentId;
            lectureAttachmentModel.FileUrl= lectureAttachment.FileUrl;

            _lectureAttachmentRepository.Update(lectureAttachmentModel);
        }

        public void Delete(int AttachmentId)
        {
            var lectureAttachmentModel = _lectureAttachmentRepository.GetById(AttachmentId);
            _lectureAttachmentRepository.Delete(lectureAttachmentModel);
        }
    }
}
