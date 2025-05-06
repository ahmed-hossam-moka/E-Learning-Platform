using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface ILectureAttachmentRepository
    {
        IQueryable<LectureAttachment> GetAll();
        LectureAttachment GetById(int id);
        void Insert(LectureAttachment lectureAttachment);
        void Update(LectureAttachment lectureAttachment);
        void Delete(LectureAttachment lectureAttachment);
    }
}
