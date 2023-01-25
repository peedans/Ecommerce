using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class TagProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductPriceId { get; set; }
        [ForeignKey("ProductPriceId")]

        public virtual Product? Product { get; set; }

        [Required]
        public int TagId { get; set; }
        [ForeignKey("TagId")]

        public virtual Tag? Tag { get; set; }

    }
}