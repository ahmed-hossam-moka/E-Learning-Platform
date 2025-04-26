using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(a => a.CourseId);

            builder.Property(a => a.Title)
                .IsRequired();

            builder.Property(a => a.Description)
                .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)") // SQL Server money type
                .HasAnnotation("Range", new[] { 0, 15000 }); // Validation range

            builder.Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue(CourseStatus.Draft);

            builder.Property(a => a.IsApproved)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(a => a.Instructor)
                .WithMany(a => a.Courses)
                .HasForeignKey(a => a.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Category)
                .WithMany(a => a.Courses)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
