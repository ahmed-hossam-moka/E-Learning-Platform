using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(a => a.InstructorId);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Bio)
                .HasMaxLength(1000);

            builder.Property(a => a.IsApproved)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // 1:1 relationship with User
            builder.HasOne(a => a.User)
                .WithOne(a => a.Instructor)
                .HasForeignKey<Instructor>(a => a.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
