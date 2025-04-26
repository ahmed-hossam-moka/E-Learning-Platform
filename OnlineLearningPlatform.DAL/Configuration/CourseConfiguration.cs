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
            // Explicitly configure CourseId as an identity column
            builder.Property(a => a.CourseId)
                .HasColumnName("CourseId") // Explicit column name (optional)
                .HasColumnType("int") // Ensure it's an integer type
                .ValueGeneratedOnAdd(); // Auto-increment

            builder.HasKey(a => a.CourseId);

            // Rest of your existing configuration...
            builder.Property(a => a.Title)
                .IsRequired();

            builder.Property(a => a.Description)
                .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasAnnotation("Range", new[] { 0, 15000 });

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

            builder.HasOne(c => c.Category)
                    .WithMany(c => c.Courses)
                    .HasForeignKey(c => c.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}