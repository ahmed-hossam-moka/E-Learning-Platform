using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
        public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
        {
            public void Configure(EntityTypeBuilder<Enrollment> builder)
            {
                builder.HasKey(a => a.EnrollmentId);

                builder.Property(a => a.EnrollmentDate)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()");

                builder.Property(a => a.IsCompleted)
                    .IsRequired()
                    .HasDefaultValue(false);

                // Relationships
                builder.HasOne(a => a.Student)
                    .WithMany(a => a.Enrollments)
                    .HasForeignKey(a => a.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(a => a.Course)
                    .WithMany(a => a.Enrollments)
                    .HasForeignKey(a => a.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(a => a.Payment)
                    .WithOne(a => a.Enrollment)
                    .HasForeignKey<Enrollment>(a => a.PaymentId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Unique constraint for student-course combination
                builder.HasIndex(a => new { a.StudentId, a.CourseId })
                    .IsUnique();
            }
        
    }
}
