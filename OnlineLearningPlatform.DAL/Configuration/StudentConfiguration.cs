using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;


namespace OnlineLearningPlatform.DAL.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(a => a.StudentId);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(a => a.User)
                .WithOne(a => a.Student)
                .HasForeignKey<Student>(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
