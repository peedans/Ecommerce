using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Tag
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public ICollection<TagProduct>? TagProduct { get; set; }
    }
}