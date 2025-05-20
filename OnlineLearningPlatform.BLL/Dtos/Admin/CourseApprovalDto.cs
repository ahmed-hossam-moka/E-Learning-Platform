using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos.Admin
{
    public class CourseApprovalDto
    {
        public int CourseId { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalNotes { get; set; }  // Optional comments
    }
}
