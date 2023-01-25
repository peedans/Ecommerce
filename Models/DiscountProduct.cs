using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class DiscountProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductPriceId { get; set; } 
        [ForeignKey("ProductPriceId")]

        public ProductPrice? ProductPrice { get; set; }

        public int DiscountPercent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}