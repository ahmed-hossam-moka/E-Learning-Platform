using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.UserId);

            builder.Property(a => a.Email)
                .IsRequired()
            .HasMaxLength(256) // Recommended length for emails
            .HasConversion(a => a!.Trim().ToLower(), a => a) // Store normalized
            .HasAnnotation("RegularExpression",@"^[^@\s]+@[^@\s]+\.[^@\s]+$"); // Simple email pattern

            builder.Property(a => a.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Role)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(a => a.Email)
                .IsUnique();
        }
    }
}
