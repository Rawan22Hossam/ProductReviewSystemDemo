using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.EntityConfiguration;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            //modelBuilder.Entity<UserProductReview>(eb => { eb.HasNoKey(); });
            
            //modelBuilder.ApplyConfiguration(new MapperConfiguration());

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        
    }
}
