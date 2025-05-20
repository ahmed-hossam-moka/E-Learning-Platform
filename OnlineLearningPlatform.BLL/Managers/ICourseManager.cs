using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface ICourseManager
    {
        public IEnumerable<CourseReadDto> GetAll();
        public CourseReadDto GetById(int Id);
        public void Add(CourseAddDto course);
        public void Update(CourseUpdateDto course);
        public void Delete(int Id);
        PagedResponseDto<IEnumerable<CourseReadDto>> GetPaginated(int pageNumber, int pageSize);
    }
}
