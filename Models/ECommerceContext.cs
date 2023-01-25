using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<DiscountProduct>? DiscountProduct { get; set; }
        public DbSet<Media>? Medias { get; set; }
        public DbSet<ProductMedia>? ProductMedia { get; set; }
        public DbSet<ProductPrice>? ProductPrice { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<ReviewMedia>? ReviewsMedia { get; set; }
        public DbSet<Tag>? Tag { get; set; }
        public DbSet<TagProduct>? TagProduct { get; set; }
        public DbSet<ProductStock>? ProductStocks { get; set; }
    }
}