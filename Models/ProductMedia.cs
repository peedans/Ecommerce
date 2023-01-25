using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class ProductMedia
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [Required]
        public int MediaId { get; set; }
        [ForeignKey("MediaId")]
        public virtual Media? Media { get; set; }
    }
}