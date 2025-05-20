using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface IEnrollmentManager 
    {
        IEnumerable<EnrollmentReadDto> GetAll();
        EnrollmentReadDto GetById(int id);
        void Insert(EnrollmentAddDto enrollment);
        void Delete(int id);
    }
}
