using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        //delete-by who/ deleted at
    }
}
