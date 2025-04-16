using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(a => a.CartId);

            builder.Property(a => a.AddedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(a => a.Student)
                .WithMany(a => a.CartItems)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Course)
                .WithMany(a => a.Carts)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint for student-course combination in cart
            builder.HasIndex(a => new { a.StudentId,a.CourseId })
                .IsUnique();
        }
    }
}
