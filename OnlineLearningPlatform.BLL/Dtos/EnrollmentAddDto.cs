using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class EnrollmentAddDto
    {
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public int PaymentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
