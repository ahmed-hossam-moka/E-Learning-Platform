using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface ILectureAttachmentManager
    {
        IEnumerable<LectureAttachmentReadDto> GetAll();
        LectureAttachmentReadDto GetById(int id);
        void Insert(LectureAttachmentAddDto lectureAttachment);
        void Update(LectureAttachmentUpdateDto lectureAttachment);
        void Delete(int AttachmentId);
    }
}
