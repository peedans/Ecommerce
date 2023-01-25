using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Review
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductPriceId { get; set; }
        [ForeignKey("ProductPriceId")]

        public ProductPrice? ProductPrice { get; set; }

        public int Point { get; set; }
        public string? Detail { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string? DisplayName { get; set; }

    }
}