using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PlatformContext _context;

        public CategoryRepository(PlatformContext context)
        {
           _context = context;
        }
        void ICategoryRepository.Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        IQueryable<Category> ICategoryRepository.GetAll()
        {
            return _context.Categories;
        }

        Category ICategoryRepository.GetById(int Id)
        {
            return _context.Categories.FirstOrDefault(predicate: a => a.CategoryId == Id);
        }

        void ICategoryRepository.Update(Category category)
        {
            _context.SaveChanges();
        }
        void ICategoryRepository.Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

        }
    }
}
