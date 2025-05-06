using OnlineLearningPlatform.BLL.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers.Users
{
    public interface IStudentManager
    {
        public IEnumerable<StudentReadDto> GetAll();
        public StudentReadDto GetById(string Id);
        public void Update(StudentUpdateDto user);
        public void Delete(string Id);
    }
}
