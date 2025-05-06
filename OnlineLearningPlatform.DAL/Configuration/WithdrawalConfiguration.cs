using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class WithdrawalConfiguration : IEntityTypeConfiguration<Withdrawal>
    {
        public void Configure(EntityTypeBuilder<Withdrawal> builder)
        {
            builder.HasKey(a => a.WithdrawalId);

            builder.Property(a => a.Amount)
                .IsRequired()
                //.HasColumnType("[Range(5, 100000)]")
                 .HasColumnType("decimal(18,2)") // SQL Server money type
                .HasAnnotation("Range", new[] { 5, 100000 }); // Validation range

            builder.Property(a => a.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue(WithdrawalStatus.Pending);

            builder.Property(a => a.RequestedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(a => a.Instructor)
                .WithMany(a => a.Withdrawals)
                .HasForeignKey(a => a.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Earnings)
                .WithMany(a => a.Withdrawals)
                .HasForeignKey(a => a.WithdrawalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
