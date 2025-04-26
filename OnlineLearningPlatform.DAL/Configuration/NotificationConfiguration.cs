using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(a => a.NotificationId);

            builder.Property(a => a.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(a => a.SentAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.IsRead)
                .IsRequired()
                .HasDefaultValue(false);

            // Relationship with User
            builder.HasOne(a => a.User)
                .WithMany(a => a.Notifications)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
