using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class LectureReadDto
    {
        public int LectureId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        //public string VideoUrl { get; set; }  //remove it not essential ? 
        public int OrderInCourse { get; set; }
        public Course Course { get; set; }
        public ICollection<LectureAttachment> Attachments { get; set; }
        public ICollection<UserLectureProgress> UserProgresses { get; set; }
    }
}
