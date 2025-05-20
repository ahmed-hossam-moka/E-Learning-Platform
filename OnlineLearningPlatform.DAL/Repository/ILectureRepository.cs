using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface ILectureRepository
    {
        IQueryable<Lecture> GetAll();
        Lecture GetById(int id);
        void Insert(Lecture lecture);
        void Update(Lecture lecture);
        void Delete(Lecture lecture);
        
    }
}
