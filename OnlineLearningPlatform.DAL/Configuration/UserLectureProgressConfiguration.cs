using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class UserLectureProgressConfiguration : IEntityTypeConfiguration<UserLectureProgress>
    {
        public void Configure(EntityTypeBuilder<UserLectureProgress> builder)
        {
            builder.HasKey(a => a.ProgressId);

            builder.Property(a => a.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Relationships
            builder.HasOne(a => a.Student)
                .WithMany(a => a.LectureProgresses)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Lecture)
                .WithMany(a => a.UserProgresses)
                .HasForeignKey(a => a.LectureId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint for student-lecture combination
            builder.HasIndex(a => new { a.StudentId, a.LectureId })
                .IsUnique();
        }
    }
}
