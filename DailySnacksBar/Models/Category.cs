using System.ComponentModel.DataAnnotations;

namespace DailySnacksBar.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(200, ErrorMessage = "Max Length {1} characters")]
        public string Description { get; set; }

        public ICollection<Snack> Snacks { get; set;} = new List<Snack>();
    }
}
