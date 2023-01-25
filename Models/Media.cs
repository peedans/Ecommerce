using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Media
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Type { get; set; }
        [Required]
        public string? Uri { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<ProductMedia>? ProductMedias { get; set; }
        public ICollection<ReviewMedia>? ReviewMedias { get; set; }

    }
}