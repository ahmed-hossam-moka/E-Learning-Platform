using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class LectureAddDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int OrderInCourse { get; set; }

    }
}
