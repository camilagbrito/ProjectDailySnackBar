using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailySnacksBar.Models
{
    public class Snack
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short descripton required")]
        [Display(Name = "Short Description")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Detailed descripton required")]
        [Display(Name = "Detailed Description")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string DetailedDescription { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Column(TypeName = "decimal(10,2)" )]
        [Range(1,999.99, ErrorMessage ="{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
        [Display(Name ="Image")]
        [StringLength(200, ErrorMessage = "{0} must be maximum of {1} characters")]
        public string ImgUrl { get; set; }

        [Display(Name = "Image")]
        [StringLength(200, ErrorMessage = "{0} must be maximum of {1} characters")]
        public string ImgThumbnailUrl { get; set; }

        [Display(Name = "Favorite")]
        public bool IsFavorite{ get; set; }
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
