using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class CategoryReadDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
