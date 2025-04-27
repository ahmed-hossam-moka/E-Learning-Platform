using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(a => a.ReviewId);

            builder.Property(a => a.Rating)
                .IsRequired()
               //.HasDefaultValueSql("[Range(1, 5)]");
                .HasColumnType("decimal(18,2)") // SQL Server money type
               .HasAnnotation("Range", new[] { 1, 5 }); // Validation range

            builder.Property(a => a.Comment)
                .HasMaxLength(1000);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(a => a.Student)
                .WithMany(a => a.Reviews)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Course)
                .WithMany(a => a.Reviews)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint for student-course review
            builder.HasIndex(a => new { a.StudentId, a.CourseId })
                .IsUnique();
        }
    }
}
