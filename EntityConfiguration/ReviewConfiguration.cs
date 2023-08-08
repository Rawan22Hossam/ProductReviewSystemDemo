using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.EntityConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {

        public void Configure(EntityTypeBuilder<Review> builder)
        {

            builder.HasKey(t => t.ReviewId);
            builder.Property(t => t.Ratings).IsRequired();
            builder.Property(t => t.Comment).IsRequired().HasMaxLength(50);
           // builder.HasOne(t => t.Common).WithMany(x => x.Review).HasForeignKey(x => x.UserId);
        }
    }
}