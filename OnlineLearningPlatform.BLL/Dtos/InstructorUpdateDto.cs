using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class InstructorUpdateDto
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public bool IsApproved { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
