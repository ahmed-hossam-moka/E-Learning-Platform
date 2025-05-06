using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }

        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public Admin Admin { get; set; }

        public ICollection<Notification> Notifications { get; set; }

    }
}
