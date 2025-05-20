using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos.Users
{
    public class StudentUpdateDto
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
