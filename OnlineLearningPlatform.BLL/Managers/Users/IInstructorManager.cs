using OnlineLearningPlatform.BLL.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers.Users
{
    public interface IInstructorManager
    {
        public IEnumerable<InstructorReadDto> GetAll();
        public InstructorReadDto GetById(string Id);
        public void Update(InstructorUpdateDto instructor);
        public void Delete(string Id);


    }
}
