using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class LectureAttachmentUpdateDto
    {
        public int AttachmentId { get; set; }
        public int LectureId { get; set; }
        public string FileUrl { get; set; }
    }
}
