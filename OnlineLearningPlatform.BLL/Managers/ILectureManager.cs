using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface ILectureManager
    {
        IEnumerable<LectureReadDto> GetAll();
        LectureReadDto GetById(int id);
        void Insert(LectureAddDto lecture);
        void Update(LectureUpdateDto lecture);
        void Delete(int id);

    }
}
