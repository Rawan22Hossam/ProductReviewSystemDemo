using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.EntityConfiguration
{
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
            public void Configure(EntityTypeBuilder<Roles> builder)
            {

                builder.HasKey(t => t.RoleId);
                builder.Property(t => t.RoleName).IsRequired().HasMaxLength(50);

                //builder.HasOne(t => t.UserProductReview).WithMany(x => x.Role).HasForeignKey(x => x.UserId);
            }
    }
}
