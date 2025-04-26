using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.CategoryId);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Unique constraint for category name
            builder.HasIndex(a => a.Name)
                .IsUnique();

            builder.HasMany(c => c.Courses)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}