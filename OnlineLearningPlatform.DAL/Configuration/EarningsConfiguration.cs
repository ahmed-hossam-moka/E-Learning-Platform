using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class EarningsConfiguration : IEntityTypeConfiguration<Earnings>
    {
        public void Configure(EntityTypeBuilder<Earnings> builder)
        {
            builder.HasKey(a => a.EarningId);

            builder.Property(a => a.Amount)
                .IsRequired()
                //.HasColumnType("[Range(0, 1000000)]");
               .HasColumnType("decimal(18,2)") // SQL Server money type
               .HasAnnotation("Range", new[] { 0, 1000000 }); // Validation range

            builder.Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue(EarningsStatus.Pending);

            builder.Property(a => a.EarnedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(a => a.Instructor)
                .WithMany(a => a.Earnings)
                .HasForeignKey(a => a.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Enrollment)
                .WithOne(a => a.Earnings)
                .HasForeignKey<Earnings>(a => a.EnrollmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
