using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }


        [Required]
        public bool IsActive { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public ICollection<ProductPrice>? ProductPrices { get; set; }
        public ICollection<TagProduct>? ProductTags { get; set; }
        public ICollection<ProductStock>? ProductStocks { get; set; }
        public ICollection<ProductMedia>? ProductMedias { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}