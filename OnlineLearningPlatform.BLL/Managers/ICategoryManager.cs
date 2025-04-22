using OnlineLearningPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineLearningPlatform.BLL.Managers
{
    public interface ICategoryManager
    {
        public ICollection<CategoryReadDto> GetAll();
        public CategoryReadDto GetById(int Id);
        public void Add(CategoryAddDto category);
        public void Update(CategoryUpdateDto category);
        public void Delete(int Id);
    }
}
