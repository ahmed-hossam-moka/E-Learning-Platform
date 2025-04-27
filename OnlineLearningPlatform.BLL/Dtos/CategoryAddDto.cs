using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class CategoryAddDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
