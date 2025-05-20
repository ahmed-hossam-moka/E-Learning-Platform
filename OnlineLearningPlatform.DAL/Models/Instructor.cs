using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineLearningPlatform.DAL.Models
{
    public class Instructor : ISoftDeletable
    {

        [Key]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public string Name { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Course>? Courses { get; set; }
        public ICollection<Announcement>? Announcements { get; set; }
        public ICollection<Earnings>? Earnings { get; set; }
        public ICollection<Withdrawal>? Withdrawals { get; set; }

    }
}
