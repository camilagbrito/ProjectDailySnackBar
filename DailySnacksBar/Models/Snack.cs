namespace DailySnacksBar.Models
{
    public class Snack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string ImgThumbnailUrl { get; set; }
        public bool IsFavorite{ get; set; }
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
