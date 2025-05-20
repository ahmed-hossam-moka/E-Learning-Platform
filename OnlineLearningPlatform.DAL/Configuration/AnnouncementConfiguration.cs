using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(a => a.AnnouncementId);

            builder.Property(a => a.Content)
                .IsRequired();

            builder.Property(a => a.SentAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(a => a.Course)
                .WithMany(a => a.Announcements)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Instructor)
                .WithMany(a => a.Announcements)
                .HasForeignKey(a => a.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
