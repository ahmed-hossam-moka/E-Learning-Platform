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
    public interface ICategoryRepository
    {
        public IQueryable<Category> GetAll();
        public Category GetById(int Id);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(Category category);
    }
}
