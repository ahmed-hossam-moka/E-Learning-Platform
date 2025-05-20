using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class CourseReadDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public CourseStatus Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; } 
    }
}
