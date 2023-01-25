using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Ecommerce.Models
{
    public class ReviewMedia
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ReviewId { get; set; }
        [ForeignKey("ReviewId")]

        public virtual Review? Review { get; set; }

        [Required]
        public int MediaId { get; set; }
        [ForeignKey("ReviewId")]

        public virtual Media? Media { get; set; }
    }
}