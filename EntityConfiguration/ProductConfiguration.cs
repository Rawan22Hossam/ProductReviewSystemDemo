using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.EntityConfiguration
{
    public class ProductConfiguration   : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.ProductId);
           builder.Property(t => t.ProductName).IsRequired();
            builder.Property(t => t.ProductPrice).IsRequired();
            builder.Property(t => t.ProductCategory).IsRequired();
           
        }
    }
}
