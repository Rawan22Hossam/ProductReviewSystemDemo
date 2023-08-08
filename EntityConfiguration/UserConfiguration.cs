using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(t => t.UserId);
            builder.Property(t => t.UserName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.PasswordHash).IsRequired();
            // builder.HasMany(t => t.Product).WithOne(x => x.User).HasForeignKey(x => x.ProductId);
            // builder.HasMany(t => t.Review).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
