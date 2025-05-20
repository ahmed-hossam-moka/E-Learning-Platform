using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos.Users
{
    public class InstructorUpdateDto
    {
        public string InstructorId { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
