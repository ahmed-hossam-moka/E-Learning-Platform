using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(a => a.PaymentId);

            builder.Property(a => a.Amount)
                .IsRequired()
                //.HasColumnType("[Range(0, 100000)]");
                .HasColumnType("decimal(18,2)") // SQL Server money type
                .HasAnnotation("Range", new[] { 0, 1000000 }); // Validation range

            builder.Property(a => a.PaymentMethod)
                .IsRequired();

            builder.Property(a => a.TransactionDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue(PaymentStatus.Pending);

            // Relationship with Student
            builder.HasOne(a => a.Student)
                .WithMany(a => a.Payments)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
