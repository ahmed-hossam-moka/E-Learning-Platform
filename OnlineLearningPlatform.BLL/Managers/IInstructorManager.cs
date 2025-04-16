using OnlineLearningPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface IInstructorManager
    {
        public IEnumerable<InstructorReadDto> GetAll();
        public InstructorReadDto GetById(int Id);
        public void Add(InstructorAddDto instructor);
        public void Update(InstructorUpdateDto instructor);
        public void Delete(int Id);


    }
}
