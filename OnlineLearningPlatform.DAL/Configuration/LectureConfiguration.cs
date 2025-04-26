using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasKey(a => a.LectureId);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Description)
                .IsRequired();

            builder.Property(a => a.VideoUrl)
                .IsRequired();

            builder.Property(a => a.OrderInCourse)
                .IsRequired();

            // Relationship with Course
            builder.HasOne(a => a.Course)
                .WithMany(a => a.Lectures)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint for lecture order within course
            builder.HasIndex(a => new { a.CourseId, a.OrderInCourse })
                .IsUnique();
        }
    }
}
