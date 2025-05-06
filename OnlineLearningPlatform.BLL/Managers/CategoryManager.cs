using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        

       

        ICollection<CategoryReadDto> ICategoryManager.GetAll()
        {
            var categoryModels = _categoryRepository.GetAll();
            var categoryDtos = categoryModels.Select(a => new CategoryReadDto
            {
                Name = a.Name,
                CategoryId = a.CategoryId
            }).ToList();
            return categoryDtos;
        }

        
        CategoryReadDto ICategoryManager.GetById(int Id)
        {
            var categoryModel = _categoryRepository.GetById(Id);
            var categoryDto = new CategoryReadDto();
            categoryDto.CategoryId = categoryModel.CategoryId;
            categoryDto.Name = categoryModel.Name;
            return categoryDto;
        }
        void ICategoryManager.Add(CategoryAddDto category)
        {
            var categoryModel = new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
            _categoryRepository.Add(categoryModel);
        }
        void ICategoryManager.Update(CategoryUpdateDto category)
        {
            var categoryModel = _categoryRepository.GetById(category.CategoryId);
            categoryModel.CategoryId = category.CategoryId;
            categoryModel.Name = category.Name;
            _categoryRepository.Update(categoryModel);
        }
        void ICategoryManager.Delete(int Id)
        {
            var categoryModel = _categoryRepository.GetById(Id);
            _categoryRepository.Delete(categoryModel);
        }
    }
}
